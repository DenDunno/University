using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Parcs.Api.Dto;

namespace RestApi.Services
{
    public class ModuleRunner : IModuleRunner
    {
        private readonly IModuleService _moduleService;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);
        private readonly ILog _log = LogManager.GetLogger(typeof(ModuleRunner));

        public ModuleRunner(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }
        
        public async Task<bool> TryRunModule(RunModuleDto module, string serverIp)
        {
            var username = Thread.CurrentPrincipal.Identity.Name;
            var userArg = string.IsNullOrEmpty(username)  ? "" : $" --user {username}";
            var commandLineParams = $@"{module.CommandLineParameters} --serverip {serverIp} --priority {module.Priority}{userArg}";
            var processStartInfo =
                new ProcessStartInfo(_moduleService.GetModuleFilePath(module.Name), commandLineParams)
                {
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };

            var process = new Process
            {
                StartInfo = processStartInfo
            };

            bool isError = false;

            process.OutputDataReceived += (sender, args) => OutputReceived(args.Data, ref isError);
            process.ErrorDataReceived += (sender, args) => Error(args.Data, out isError);

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await _semaphore.WaitAsync();
            return !isError;
        }
        
        private void OutputReceived(string data, ref bool isError)
        {
            _log.Info("MODULE OUTPUT: " + data);
            if (string.IsNullOrEmpty(data))
            {
                return;                
            }
            if (data.ToUpper().Contains("ERROR"))
            {
                isError = true;
                _semaphore.Release();
                return;
            }

            if (data.StartsWith("connection to host", StringComparison.InvariantCultureIgnoreCase))
            {
                _semaphore.Release();
            }
        }

        private void Error(string data, out bool isError)
        {
            _log.Info("MODULE ERROR RECEIVED: " + data);
            isError = true;
            _semaphore.Release();
        }
    }
}
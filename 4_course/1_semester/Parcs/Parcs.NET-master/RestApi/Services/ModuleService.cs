using System.Configuration;
using System.IO;
using System.Linq;

namespace RestApi.Services
{
    public class ModuleService : IModuleService
    {
        private readonly string _moduleFolder = ConfigurationManager.AppSettings["moduleFolder"];

        public string[] GetAvailableModules()
        {
            return Directory.GetDirectories(_moduleFolder).Select(Path.GetFileName).ToArray();
        }

        public string GetModuleFilePath(string moduleName)
        {
            return Path.Combine(_moduleFolder, moduleName, $"{moduleName}.exe");
        }
    }
}
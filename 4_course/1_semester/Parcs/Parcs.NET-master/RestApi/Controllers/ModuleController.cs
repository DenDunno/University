using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Parcs.Api.Dto;
using RestApi.Services;

namespace RestApi.Controllers
{
    public class ModuleController: ApiController
    {
        private readonly IModuleRunner _moduleRunner;
        private readonly IParcsService _parcsService;
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleRunner moduleRunner, IParcsService parcsService, IModuleService moduleService)
        {
            _moduleRunner = moduleRunner;
            _parcsService = parcsService;
            _moduleService = moduleService;
        }

        [HttpGet]
        public ModuleDto[] Get()
        {
            return _moduleService.GetAvailableModules().Select(m => new ModuleDto {Name = m}).ToArray();
        }

        [HttpPost]
        [ActionName("run")]
        public async Task<IHttpActionResult> RunModule(RunModuleDto moduleDto)
        {
            if (string.IsNullOrEmpty(moduleDto.Name))
            {
                throw new ArgumentException("Value cannot be null or empty", nameof(moduleDto.Name));
            }

            var serverIp = await _parcsService.GetServerIp();
            bool isRunSuccessfully = await _moduleRunner.TryRunModule(moduleDto, serverIp);
            if (!isRunSuccessfully)
            {
                throw new InvalidOperationException("Module didn't start successfully");
            }
            return Ok();
        }
    }
}
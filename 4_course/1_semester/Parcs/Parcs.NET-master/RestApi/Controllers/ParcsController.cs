using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using Parcs.Api.Dto;
using RestApi.Services;

namespace RestApi.Controllers
{
    [AllowAnonymous]
    public class ParcsController : ApiController
    {
        private readonly IParcsService _parcsService;

        public ParcsController(IParcsService parcsService)
        {
            _parcsService = parcsService;
        }

        [HttpGet]
        [ActionName("job")]
        public Task<JobInfoDto[]> GetJobs()
        {
            return _parcsService.GetJobs();
        }

        [HttpGet]
        [ActionName("host")]
        public Task<HostInfoDto[]> GetHosts()
        {
            return _parcsService.GetHosts();
        }

        [Authorize]
        [HttpPost]
        [ActionName("cancelJob")]
        public async Task<IHttpActionResult> Cancel(CancelJobDto cancelJobDto)
        {
            await _parcsService.CancelJob(cancelJobDto);
            return Ok();
        }
    }
}
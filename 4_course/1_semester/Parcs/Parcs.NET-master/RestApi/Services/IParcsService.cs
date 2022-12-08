using System.Threading.Tasks;
using Parcs.Api.Dto;

namespace RestApi.Services
{
    public interface IParcsService
    {
        Task<JobInfoDto[]> GetJobs();
        Task<HostInfoDto[]> GetHosts();
        Task CancelJob(CancelJobDto cancelJobDto);
        Task<string> GetServerIp();
    }
}
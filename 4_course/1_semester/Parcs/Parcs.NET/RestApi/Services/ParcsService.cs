using System;
using System.Configuration;
using System.Threading.Tasks;
using Parcs.Api.Dto;

namespace RestApi.Services
{
    public class ParcsService : IParcsService
    {
        private readonly IRestApiClient _restApiClient;

        private readonly string _hostServerUrl =
            Environment.GetEnvironmentVariable(EnvironmentVariables.HostServerUrl) ??
            ConfigurationManager.AppSettings["hostServerUrl"];

        public ParcsService(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }
        
        public Task<JobInfoDto[]> GetJobs()
        {
            return _restApiClient.GetAsync<JobInfoDto[]>($"{_hostServerUrl}/api/job");
        }

        public Task<HostInfoDto[]> GetHosts()
        {
            return _restApiClient.GetAsync<HostInfoDto[]>($"{_hostServerUrl}/api/host/list");
        }

        public Task CancelJob(CancelJobDto dto)
        {
            return _restApiClient.PostAsync($"{_hostServerUrl}/api/job/cancel", dto);
        }

        public Task<string> GetServerIp()
        {
            return _restApiClient.GetAsync<string>($"{_hostServerUrl}/api/host/serverip");
        }
    }
}
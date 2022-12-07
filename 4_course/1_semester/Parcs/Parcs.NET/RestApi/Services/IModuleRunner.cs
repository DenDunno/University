using System.Threading.Tasks;
using Parcs.Api.Dto;

namespace RestApi.Services
{
    public interface IModuleRunner
    {
        Task<bool> TryRunModule(RunModuleDto module, string serverIp);
    }
}

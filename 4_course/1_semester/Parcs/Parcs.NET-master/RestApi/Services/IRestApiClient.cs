using System.Threading.Tasks;

namespace RestApi.Services
{
    public interface IRestApiClient
    {
        Task<T> GetAsync<T>(string url);
        Task PostAsync(string url, object content);
    }
}
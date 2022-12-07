using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class RestApiClient : IRestApiClient
    {
        public async Task<T> GetAsync<T>(string url)
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(url);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadAsAsync<T>();
        }

        public async Task PostAsync(string url, object content)
        {
            var httpClient = new HttpClient();
            var result = await httpClient.PostAsync(url, new ObjectContent<object>(content, new JsonMediaTypeFormatter()));
            result.EnsureSuccessStatusCode();
        }
    }
}
using System.Net.Http;
using System.Threading.Tasks;

namespace IlyaSaukoNancyTask.Services
{
    ///<inheritdoc cref="IHttpRequestService"/>
    public class HttpRequestService : IHttpRequestService
    {
        private readonly HttpClient _client;

        public HttpRequestService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetListAsync(string section) =>
            await _client.GetStringAsync($"https://api.nytimes.com/svc/topstories/v2/{section}.json?api-key=k0XA0k0jJGAVuv8Jr5wAIcKDGPuznmRJ");
    }
}
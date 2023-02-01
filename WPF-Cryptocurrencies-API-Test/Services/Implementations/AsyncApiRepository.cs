using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AsyncApiRepository : IAsyncApiRepository
    {
        private readonly HttpClient httpClient;

        public AsyncApiRepository(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<T> GetAsync<T>(Uri resourceUri)
        {
            var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, resourceUri))
            .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            try
            {
                return JsonSerializer.Deserialize<T>(responseContent);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }
    }
}

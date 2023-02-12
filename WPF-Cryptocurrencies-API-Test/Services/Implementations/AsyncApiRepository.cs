using Services.Interfaces;
using System.Text.Json;

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
            try
            {
                var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, resourceUri))
                    .ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<T>(responseContent);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.Requests
{
    public class CoinCapAPIRequest
    {
        public Task<string> GetStringResponse(string address)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(address).Result;
                response.EnsureSuccessStatusCode();

                return Task.FromResult(response.Content.ReadAsStringAsync().Result);

            }
            catch (Exception ex)
            {
                throw new Exception($"ApiJsonRequest.GetStringResponse: {ex.Message}");

            }

        }
    }
}

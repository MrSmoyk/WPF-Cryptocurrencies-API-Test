using Domain.Constants;
using Domain.DTOs;
using Newtonsoft.Json;
using Services.Interfaces;
using Services.Requests;

namespace Services.Implementations
{
    public class AssertsInfoService : IAssertsInfoService
    {
        public async Task<data> GetDataFromAPI()
        {
            try
            {
                var jsonResponse = await new CoinCapAPIRequest().GetStringResponse(CoinCapAPI20APIURL.GETAssets);

                var data = JsonConvert.DeserializeObject<data>(jsonResponse);


                if (data == null || data.AssetsInfoList.Count == 0)
                {
                    throw new FormatException();
                }

                return data;

            }
            catch (Exception ex)
            {
                throw new Exception($"ExchangeRateService.GetBaseCurrency: {ex.Message}");
            }
        }
    }
}

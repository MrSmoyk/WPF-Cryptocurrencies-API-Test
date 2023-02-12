using System.Text.Json.Serialization;

namespace Domain.DTOs.CoinsDTOs
{
    public class CoinFullDataDTO : CoinFullDataWithOutMarketDataDTO
    {
        [JsonPropertyName("market_data")]
        public MarketDataDTO MarketData { get; set; }
    }
}

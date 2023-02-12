using System.Text.Json.Serialization;

namespace Domain.DTOs.CoinsDTOs
{
    public class MarketChartByIdDTO
    {
        [JsonPropertyName("prices")]
        public decimal?[][] Prices { get; set; }

        [JsonPropertyName("market_caps")]
        public decimal?[][] MarketCaps { get; set; }

        [JsonPropertyName("total_volumes")]
        public decimal?[][] TotalVolumes { get; set; }
    }
}

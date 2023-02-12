using System.Text.Json.Serialization;

namespace Domain.DTOs.SharedDTOs
{
    public class MarketDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("has_trading_incentive")]
        public bool HasTradingIncentive { get; set; }
    }
}

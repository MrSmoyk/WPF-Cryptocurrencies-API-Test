using Domain.DTOs.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.CoinsDTOs
{
    public class CoinByIdMarketDataDTO : MarketDataDTO
    {
        [JsonPropertyName("ath")]
        public Dictionary<string, decimal> Ath { get; set; }

        [JsonPropertyName("ath_change_percentage")]
        public Dictionary<string, decimal> AthChangePercentage { get; set; }

        [JsonPropertyName("total_value_locked")]
        public Dictionary<string, decimal> TotalValueLocked { get; set; }

        [JsonPropertyName("ath_date")]
        public Dictionary<string, DateTimeOffset?> AthDate { get; set; }

        [JsonPropertyName("atl")]
        public Dictionary<string, decimal> Atl { get; set; }

        [JsonPropertyName("atl_change_percentage")]
        public Dictionary<string, decimal> AtlChangePercentage { get; set; }

        [JsonPropertyName("atl_date")]
        public Dictionary<string, DateTimeOffset?> AtlDate { get; set; }

        [JsonPropertyName("sparkline_7d")]
        public SparklineIn7dDTO Sparkline7D { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }
    }
}

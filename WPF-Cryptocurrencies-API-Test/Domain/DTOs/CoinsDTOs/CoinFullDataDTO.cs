using Domain.DTOs.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.CoinsDTOs
{
    public class CoinFullDataDTO : CoinFullDataWithOutMarketDataDTO
    {
        [JsonPropertyName("market_data")]
        public MarketDataDTO MarketData { get; set; }
    }
}

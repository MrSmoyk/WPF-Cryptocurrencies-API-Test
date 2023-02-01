﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.GlobalDTOs
{
    public class GlobalDataDTO
    {
        [JsonPropertyName("active_cryptocurrencies")]
        public long? ActiveCryptocurrencies { get; set; }

        [JsonPropertyName("upcoming_icos")]
        public long? UpcomingIcos { get; set; }

        [JsonPropertyName("ongoing_icos")]
        public long? OngoingIcos { get; set; }

        [JsonPropertyName("ended_icos")]
        public long? EndedIcos { get; set; }

        [JsonPropertyName("markets")]
        public long? Markets { get; set; }

        [JsonPropertyName("total_market_cap")]
        public Dictionary<string, double> TotalMarketCap { get; set; }

        [JsonPropertyName("total_volume")]
        public Dictionary<string, double> TotalVolume { get; set; }

        [JsonPropertyName("market_cap_percentage")]
        public Dictionary<string, double> MarketCapPercentage { get; set; }

        [JsonPropertyName("updated_at")]
        public long? UpdatedAt { get; set; }

        [JsonPropertyName("market_cap_change_percentage_24h_usd")]
        public decimal MarketCapChange { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.CoinsDTOs
{
    public class RoiDTO
    {
        [JsonPropertyName("times")]
        public decimal? Times { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("percentage")]
        public decimal? Percentage { get; set; }
    }
}

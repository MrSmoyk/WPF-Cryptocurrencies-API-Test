using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.SharedDTOs
{
    public class PublicInterestStatsDTO
    {
        [JsonPropertyName("alexa_rank")]
        public long? AlexaRank { get; set; }

        [JsonPropertyName("bing_matches")]
        public long? BingMatches { get; set; }
    }
}

using System.Text.Json.Serialization;

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

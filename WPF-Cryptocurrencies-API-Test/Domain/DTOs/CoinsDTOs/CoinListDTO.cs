using System.Text.Json.Serialization;

namespace Domain.DTOs.CoinsDTOs
{
    public class CoinListDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("platforms")]
        public Dictionary<string, string> Platforms { get; set; }
    }
}

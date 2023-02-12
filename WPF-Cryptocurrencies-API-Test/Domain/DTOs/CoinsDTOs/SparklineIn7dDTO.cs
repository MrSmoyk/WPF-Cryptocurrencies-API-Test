using System.Text.Json.Serialization;

namespace Domain.DTOs.CoinsDTOs
{
    public class SparklineIn7dDTO
    {
        [JsonPropertyName("price")]
        public decimal[] Price { get; set; }
    }
}

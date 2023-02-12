using System.Text.Json.Serialization;

namespace Domain.DTOs.SharedDTOs
{
    public class ImageDTO
    {
        [JsonPropertyName("thumb")]
        public Uri Thumb { get; set; }

        [JsonPropertyName("small")]
        public Uri Small { get; set; }

        [JsonPropertyName("large")]
        public Uri Large { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

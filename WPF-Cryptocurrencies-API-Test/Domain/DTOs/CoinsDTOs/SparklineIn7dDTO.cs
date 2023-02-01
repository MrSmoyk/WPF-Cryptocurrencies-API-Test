using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.CoinsDTOs
{
    public class SparklineIn7dDTO
    {
        [JsonPropertyName("price")]
        public decimal[] Price { get; set; }
    }
}

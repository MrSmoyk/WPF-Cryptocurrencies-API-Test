using Domain.DTOs.SharedDTOs;
using System.Text.Json.Serialization;

namespace Domain.DTOs.CoinsDTOs
{
    public class TickerByIdDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tickers")]
        public TickerDTO[] Tickers { get; set; }
    }
}

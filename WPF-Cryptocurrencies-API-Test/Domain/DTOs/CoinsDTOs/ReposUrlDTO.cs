using System.Text.Json.Serialization;

namespace Domain.DTOs.CoinsDTOs
{
    public class ReposUrlDTO
    {
        [JsonPropertyName("github")]
        public Uri[] Github { get; set; }

        [JsonPropertyName("bitbucket")]
        public object[] Bitbucket { get; set; }
    }
}

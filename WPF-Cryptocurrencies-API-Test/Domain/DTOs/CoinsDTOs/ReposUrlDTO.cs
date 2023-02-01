using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

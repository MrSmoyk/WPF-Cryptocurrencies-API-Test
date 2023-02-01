using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.GlobalDTOs
{
    public class GlobalDeFiDTO
    {
        [JsonPropertyName("data")]
        public GlobalDeFiDTO Data { get; set; }
    }
}

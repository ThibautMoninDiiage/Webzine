using System;
using System.Text.Json.Serialization;

namespace Webzine.Entity.DTO
{
    public class DeezerRequestRootDTO
    {
        [JsonPropertyName("data")]
        public List<TitreDTO> Data { get; set; }
    }
}


using System;
using Newtonsoft.Json;

namespace Webzine.Entity.DTO
{
    public class DeezerRequestTitreDTO
    {
        [JsonProperty("data")]
        public List<TitreDTO> Titres { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("prev")]
        public string Prev { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}


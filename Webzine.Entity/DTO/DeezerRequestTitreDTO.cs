using System;
using Newtonsoft.Json;

namespace Webzine.Entity.DTO
{
    public class DeezerRequestTitreDTO
    {
        [JsonProperty("data")]
        public List<TitreDTO> Titres { get; set; }
    }
}


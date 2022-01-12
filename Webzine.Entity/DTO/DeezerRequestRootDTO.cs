using System;
using Newtonsoft.Json;

namespace Webzine.Entity.DTO
{
    public class DeezerRequestRootDTO
    {
        [JsonProperty("data")]
        public List<TitreDTO> Titres { get; set; }

        //[JsonProperty("data")]
        //public List<StyleDTO> Styles { get; set; }
    }
}


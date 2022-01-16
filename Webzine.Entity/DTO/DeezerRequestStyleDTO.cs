using Newtonsoft.Json;

namespace Webzine.Entity.DTO
{
    public class DeezerRequestStyleDTO
    {
        [JsonProperty("data")]
        public List<StyleDTO> Styles { get; set; }
    }
}


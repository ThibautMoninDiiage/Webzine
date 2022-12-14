using System.Text.Json.Serialization;

namespace Webzine.Entity.DTO
{
    public class StyleDTO
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("picture")]
        public string Picture { get; set; }

        [JsonPropertyName("picture_small")]
        public string PictureSmall { get; set; }

        [JsonPropertyName("picture_medium")]
        public string PictureMedium { get; set; }

        [JsonPropertyName("picture_big")]
        public string PictureBig { get; set; }

        [JsonPropertyName("picture_xl")]
        public string PictureXl { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }


        public StyleDTO()
        {
        }
    }
}


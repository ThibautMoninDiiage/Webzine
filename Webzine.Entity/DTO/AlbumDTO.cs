using System;
using System.Text.Json.Serialization;

namespace Webzine.Entity.DTO
{
    public class AlbumDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("cover")]
        public string Cover { get; set; }

        [JsonPropertyName("cover_small")]
        public string CoverSmall { get; set; }

        [JsonPropertyName("cover_medium")]
        public string CoverMedium { get; set; }

        [JsonPropertyName("cover_big")]
        public string CoverBig { get; set; }

        [JsonPropertyName("cover_xl")]
        public string CoverXl { get; set; }

        [JsonPropertyName("md5_image")]
        public string Md5Image { get; set; }

        [JsonPropertyName("tracklist")]
        public string Tracklist { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}


﻿using Newtonsoft.Json;

namespace Webzine.Entity.DTO
{
    public class AlbumDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("cover_small")]
        public string CoverSmall { get; set; }

        [JsonProperty("cover_medium")]
        public string CoverMedium { get; set; }

        [JsonProperty("cover_big")]
        public string CoverBig { get; set; }

        [JsonProperty("cover_xl")]
        public string CoverXl { get; set; }

        [JsonProperty("md5_image")]
        public string Md5Image { get; set; }

        [JsonProperty("tracklist")]
        public string Tracklist { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}


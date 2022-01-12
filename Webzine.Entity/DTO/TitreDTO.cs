using System;
using System.Text.Json.Serialization;

namespace Webzine.Entity.DTO
{
    public class TitreDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("preview")]
        public string Preview { get; set; }

        [JsonPropertyName("artist")]
        public ArtistDTO Artist { get; set; }

        [JsonPropertyName("album")]
        public AlbumDTO Album { get; set; }
    }
}


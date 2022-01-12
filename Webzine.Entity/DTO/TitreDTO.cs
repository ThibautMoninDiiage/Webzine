using System;
using Newtonsoft.Json;
using Webzine.Entity.Interfaces;

namespace Webzine.Entity.DTO
{
    public class TitreDTO
    {
        [JsonProperty("id")]
        public int IdTitre { get; set; }

        public int IdArtiste { get; set; }

        [JsonProperty("artist")]
        public ArtistDTO Artiste { get; set; }

        [JsonProperty("title")]
        public string Libelle { get; set; }

        public string Chronique { get; set; }

        public DateTime DateCreation { get; set; }

        [JsonProperty("duration")]
        public int Duree { get; set; }

        public DateTime DateSortie { get; set; }

        public string UrlJaquette { get; set; }

        [JsonProperty("preview")]
        public string UrlEcoute { get; set; }

        [JsonProperty("rank")]
        public int NbLectures { get; set; }

        public int NbLikes { get; set; }

        [JsonProperty("album")]
        public AlbumDTO AlbumDTO { get; set; }

        public string Album { get; set; }

        public List<Style> TitresStyles { get; set; }
        public List<Commentaire> Commentaires { get; set; }

        public TitreDTO()
        {

        }
    }
}


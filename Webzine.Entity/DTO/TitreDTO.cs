using System;
using Newtonsoft.Json;
using Webzine.Entity.Interfaces;

namespace Webzine.Entity.DTO
{
    public class TitreDTO : ITitre
    {
        [JsonProperty("id")]
        public int IdTitre { get; set; }

        public int IdArtiste { get; set; }

        [JsonProperty("artist")]
        public Artiste Artiste { get; set; }

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



        public TitreDTO(ITitre titre)
        {
            this.IdArtiste = titre.IdArtiste;
            this.IdArtiste = titre.IdArtiste;
            this.Artiste = titre.Artiste;
            this.Libelle = titre.Libelle;
            this.Chronique = titre.Chronique;
            this.DateCreation = titre.DateCreation;
            this.Duree = titre.Duree;
            this.DateSortie = titre.DateSortie;
            this.UrlJaquette = titre.UrlJaquette;
            this.UrlEcoute = titre.UrlEcoute;
            this.NbLectures = titre.NbLectures;
            this.NbLikes = titre.NbLikes;
            this.Album = titre.Album;
            this.TitresStyles = titre.TitresStyles;
            this.Commentaires = titre.Commentaires;
        }
    }

    
}


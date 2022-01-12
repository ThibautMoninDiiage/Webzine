using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Webzine.Entity.Interfaces;

namespace Webzine.Entity
{
    public class Titre : ITitre
    {
        [Key]
        public int IdTitre { get; set; }
        public int IdArtiste { get; set; }
        public Artiste Artiste { get; set; }

        [Required]
        [Display(Name = "Titre")]
        [MinLength(1)]
        [MaxLength(200)]
        [JsonProperty("title")]
        public string Libelle { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(4000)]
        public string Chronique { get; set; }

        [Required]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }

        [Required]
        [Display(Name = "Durée en secondes")]
        public int Duree { get; set; }

        [Required]
        [Display(Name = "Date de sortie")]
        public DateTime DateSortie { get; set; }

        [Required]
        [Display(Name = "Jaquette de l'album")]
        [MaxLength(250)]
        public string UrlJaquette { get; set; }

        [Display(Name = "URL d'écoute")]
        [MinLength(13)]
        [MaxLength(250)]
        public string UrlEcoute { get; set; }

        [Required]
        [Display(Name = "Nombre de lectures")]
        public int NbLectures { get; set; }

        [Required]
        [Display(Name = "Nombre de likes")]
        public int NbLikes { get; set; }

        [Required]
        public string Album { get; set; }
        public List<Style> TitresStyles { get; set; }
        public List<Commentaire> Commentaires { get; set; }

        public Titre()
        {

        }

        public Titre(ITitre titre)
        {
            this.IdTitre = titre.IdTitre;
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

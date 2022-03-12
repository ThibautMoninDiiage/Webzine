using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Webzine.Entity.Interfaces;

namespace Webzine.Entity
{
    public class Titre : ITitre
    {
        [Key]
        public int IdTitre { get; set; }

        [ForeignKey(nameof(Artiste))]
        public int IdArtiste { get; set; }

        public Artiste Artiste { get; set; }

        [Required(ErrorMessage = "Vous devez remplir les champs requis!")]
        [Display(Name = "Titre")]
        [MinLength(1, ErrorMessage = "Vous devez au moins mettre un charactère!")]
        [MaxLength(200, ErrorMessage = "Vous devez pas mettre plus de 200 charactères!")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9.]*$", ErrorMessage = "/, * et _ ne sont pas autorisés!")]
        [JsonProperty("title")]
        public string Libelle { get; set; }

        [Required(ErrorMessage = "Vous devez remplir les champs requis!")]
        [MinLength(10, ErrorMessage = "Vous devez au moins mettre 10 charactères!")]
        [MaxLength(4000, ErrorMessage = "Vous devez pas mettre plus de 4000 charactères!")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9.]*$", ErrorMessage = "/, * et _ ne sont pas autorisés!")]
        public string Chronique { get; set; }

        [Required(ErrorMessage = "Vous devez remplir les champs requis!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyyHH:mm}")]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }

        [Required]
        [Display(Name = "Durée en secondes")]
        public int Duree { get; set; }

        [Required(ErrorMessage = "Vous devez remplir les champs requis!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Date de sortie")]
        public DateTime DateSortie { get; set; }

        [Required(ErrorMessage = "Vous devez remplir les champs requis!")]
        [Display(Name = "Jaquette de l'album")]
        [MaxLength(250, ErrorMessage = "Vous devez pas mettre plus de 250 charactères!")]
        public string UrlJaquette { get; set; }

        [Display(Name = "URL d'écoute")]
        [MinLength(13, ErrorMessage = "Vous devez au moins mettre 13 charactères!")]
        [MaxLength(250, ErrorMessage = "Vous devez pas mettre plus de 250 charactères!")]
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

        public Titre(int idTitre, int idArtiste, Artiste artiste, string libelle, string chronique, DateTime dateCreation, int duree, DateTime dateSortie, string urlJaquette, string urlEcoute, int nbLectures, int nbLikes, string album, List<Style> titresStyles)
        {
            IdTitre = idTitre;
            IdArtiste = idArtiste;
            Artiste = artiste;
            Libelle = libelle;
            Chronique = chronique;
            DateCreation = dateCreation;
            Duree = duree;
            DateSortie = dateSortie;
            UrlJaquette = urlJaquette;
            UrlEcoute = urlEcoute;
            NbLectures = nbLectures;
            NbLikes = nbLikes;
            Album = album;
            TitresStyles = titresStyles;
        }
    }
}

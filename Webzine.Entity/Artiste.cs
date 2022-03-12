using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Webzine.Entity.Interfaces;

namespace Webzine.Entity
{
    public class Artiste : IArtiste
    {
        [Key]
        [JsonProperty("id")]
        public int IdArtiste { get; set; }

        [Required(ErrorMessage = "Vous devez remplir les champs requis!")]
        [MinLength(1, ErrorMessage = "Vous devez au moins mettre un charactère!")]
        [MaxLength(50, ErrorMessage = "Vous devez pas mettre plus de 50 charactères!")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9.]*$", ErrorMessage = "/, * et _ ne sont pas autorisés!")]
        [Display(Name = "Nom de l'artiste")]
        [JsonProperty("name")]
        public string Nom { get; set; }

        public string Biographie { get; set; }

        public List<Titre> Titres { get; set; }

        public DateTime DateNaissance { get; set; }

        [JsonProperty("link")]
        public string UrlSite { get; set; }

        public Artiste()
        {

        }

        public Artiste(int idArtiste, string nom, string biographie, DateTime dateNaissance, string urlSite)
        {
            IdArtiste = idArtiste;
            Nom = nom;
            Biographie = biographie;
            DateNaissance = dateNaissance;
            UrlSite = urlSite;
        }

        public Artiste(IArtiste artiste)
        {
            this.IdArtiste = artiste.IdArtiste;
            this.Nom = artiste.Nom;
            this.Biographie = artiste.Biographie;
            this.Titres = artiste.Titres;
            this.DateNaissance = artiste.DateNaissance;
            this.UrlSite = artiste.UrlSite;
        }
    }
}

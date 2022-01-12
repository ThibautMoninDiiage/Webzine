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

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Nom de l'artiste")]
        [JsonProperty("name")]
        public string Nom { get; set; }

        [Required]
        public string Biographie { get; set; }

        [Required]
        public List<Titre> Titres { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        [Required]
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

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Webzine.Entity
{
    public class Style
    {
        [Key]
        [JsonProperty("id")]
        public int IdStyle { get; set; }

        [Required(ErrorMessage = "Vous devez remplir les champs requis!")]
        [Display(Name = "Libellé")]
        [MinLength(2, ErrorMessage = "Vous devez au moins mettre 2 charactères!")]
        [MaxLength(50, ErrorMessage = "Vous devez pas mettre plus de 50 charactères!")]
        [JsonProperty("name")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9.]*$", ErrorMessage = "/, * et _ ne sont pas autorisés!")]
        public string Libelle { get; set; }

        public List<Titre> TitresStyles { get; set; }
    }
}

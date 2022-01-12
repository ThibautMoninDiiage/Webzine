using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.DTO
{
    public class StyleDTO : Style
    {
        [Key]
        [JsonProperty("id")]
        public int IdStyle { get; set; }

        [Required]
        [Display(Name = "Libellé")]
        [MinLength(2)]
        [MaxLength(50)]
        [JsonProperty("name")]
        public string Libelle { get; set; }
        public List<Titre> TitresStyles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity
{
    public class Style
    {
        public int IdStyle { get; set; }

        [Required]
        [Display(Name = "Libellé")]
        [MinLength(2)]
        [MaxLength(50)]
        public string Libelle { get; set; }
        public List<Titre> TitresStyles { get; set; }
    }
}

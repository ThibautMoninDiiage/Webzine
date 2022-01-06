using System.ComponentModel.DataAnnotations;

namespace Webzine.Entity
{
    public class Commentaire
    {
        public int IdCommentaire { get; set; }

        [Required]
        [Display(Name = "Commentaire")]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Contenu { get; set; }

        [Required]
        [Display(Name = "Nom")]
        [MinLength(2)]
        [MaxLength(30)]
        public string Auteur { get; set; }

        [Required]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }
        public int IdTitre { get; set; }
        public Titre Titre { get; set; }
    }
}

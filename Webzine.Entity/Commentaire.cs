using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webzine.Entity
{
    public class Commentaire
    {
        [Key]
        public int IdCommentaire { get; set; }

        [Required(ErrorMessage = "Vous devez remplir les champs requis!")]
        [Display(Name = "Commentaire")]
        [MinLength(10, ErrorMessage = "Vous devez au moins mettre 10 charactères!")]
        [MaxLength(1000, ErrorMessage = "Vous devez pas mettre plus de 1000 charactères!")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9.]*$", ErrorMessage = "/, * et _ ne sont pas autorisés!")]
        public string Contenu { get; set; }

        [Required(ErrorMessage = "Vous devez remplir les champs requis!")]
        [Display(Name = "Nom")]
        [MinLength(2, ErrorMessage = "Vous devez au moins mettre 2 charactères!")]
        [MaxLength(30, ErrorMessage = "Vous devez pas mettre plus de 30 charactères!")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9.]*$", ErrorMessage = "/, * et _ ne sont pas autorisés!")]
        public string Auteur { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }

        [ForeignKey(nameof(Titre))]
        public int IdTitre { get; set; }

        public Titre? Titre { get; set; }
    }
}

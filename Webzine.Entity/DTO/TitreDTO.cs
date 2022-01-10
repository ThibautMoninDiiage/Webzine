using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.DTO
{
    public class TitreDTO : Titre
    {
        [Key]
        public int IdTitre { get; set; }
        public int IdArtiste { get; set; }
        public Artiste Artiste { get; set; }

        [Required]
        [Display(Name = "Titre")]
        [MinLength(1)]
        [MaxLength(200)]
        public string Libelle { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(4000)]
        public string Chronique { get; set; }

        [Required]
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; }

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
    }
}

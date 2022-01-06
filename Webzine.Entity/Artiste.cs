﻿using System.ComponentModel.DataAnnotations;

namespace Webzine.Entity
{
    public class Artiste
    {
        [Key]
        public int IdArtiste { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Display(Name = "Nom de l'artiste")]
        public string Nom { get; set; }

        [Required]
        public string Biographie { get; set; }

        [Required]
        public List<Titre> Titres { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        [Required]
        public string UrlSite { get; set; }
    }
}

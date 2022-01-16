using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.Interfaces
{
    public interface IArtiste
    {
        public int IdArtiste { get; set; }
        public string Nom { get; set; }
        public string Biographie { get; set; }
        public List<Titre> Titres { get; set; }
        public DateTime DateNaissance { get; set; }
        public string UrlSite { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity
{
    public class ArtistesTitres
    {
        public int IdArtiste { get; set; }
        public Artiste Artiste { get; set; }
        public int IdTitre { get; set; }
        public Titre Titre { get; set; }
    }
}

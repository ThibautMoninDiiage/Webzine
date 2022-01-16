using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.Interfaces
{
    public interface ITitre
    {
        public int IdTitre { get; set; }
        public int IdArtiste { get; set; }
        public Artiste Artiste { get; set; }
        public string Libelle { get; set; }
        public string Chronique { get; set; }
        public DateTime DateCreation { get; set; }
        public int Duree { get; set; }
        public DateTime DateSortie { get; set; }
        public string UrlJaquette { get; set; }
        public string UrlEcoute { get; set; }
        public int NbLectures { get; set; }
        public int NbLikes { get; set; }
        public string Album { get; set; }
        public List<Style> TitresStyles { get; set; }
        public List<Commentaire> Commentaires { get; set; }
    }
}

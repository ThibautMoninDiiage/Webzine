using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.Factory
{
    public static class HomeFactory
    {
        public static IEnumerable<Style> CreateStyles()
        {
            return new List<Style>()
            {
                new Style(){ IdStyle = 1, Libelle = "Rap" },
                new Style(){ IdStyle = 2, Libelle = "Rock" },
                new Style(){ IdStyle = 3, Libelle = "Pop" },
                new Style(){ IdStyle = 4, Libelle = "Classique" },
                new Style(){ IdStyle = 5, Libelle = "Americain" },
                new Style(){ IdStyle = 6, Libelle = "Nul" },
                new Style(){ IdStyle = 7, Libelle = "A" },
                new Style(){ IdStyle = 8, Libelle = "B" },
                new Style(){ IdStyle = 9, Libelle = "Gabon" },
                new Style(){ IdStyle = 10, Libelle = "Jazz" }
            };
        }
    }
}

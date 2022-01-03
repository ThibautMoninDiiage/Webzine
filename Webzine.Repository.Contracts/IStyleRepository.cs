using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface IStyleRepository
    {
        // Ajoute un nouveau style de musique.
        void Add(Style style);
        // Supprime un style de musique.
        void Delete(Style style);
        // Retourne le style de musique demandé.
        Style Find(int id);
    }
}

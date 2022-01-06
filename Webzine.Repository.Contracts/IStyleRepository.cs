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
        // Retourne tous les styles de musique.
        IEnumerable<Style> FindAll();
        // Met à jour un style de musique.
        void Update(Style style);
    }
}

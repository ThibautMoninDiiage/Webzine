using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface IArtisteRepository
    {
        // Ajoute un nouvel artiste.
        void AddArtiste(Artiste artiste);
        // Supprime un artiste.
        void DeleteArtiste(Artiste artiste);
        // Met à jour un artiste.
        void UpdateArtiste(Artiste artiste);
        // Retourne l'artiste demandé.
        Artiste Find(int id);
        // Retourne tous les artistes.
        IEnumerable<Artiste> FindAll();
    }
}

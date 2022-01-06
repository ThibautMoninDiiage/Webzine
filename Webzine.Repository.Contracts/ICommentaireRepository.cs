using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface ICommentaireRepository
    {
        // Ajoute un nouveau commentaire.
        void Add(Commentaire commentaire);
        // Supprime un commentaire.
        void Delete(Commentaire commentaire);
        // Retourne le commentaire demandé.
        Commentaire Find(int id);
        // Retourne tous les commentaires.
        IEnumerable<Commentaire> FindAll();
    }
}

using System;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Factory
{
    public class FactoryCommentaireRepository : ICommentaireRepository
    {
        public FactoryCommentaireRepository()
        {
        }

        public void Add(Commentaire commentaire)
        {
            throw new NotImplementedException();
        }

        public void Delete(Commentaire commentaire)
        {
        }

        public Commentaire Find(int id)
        {
            try
            {
                var commentaire = TitleFactory.CreateTitles().SelectMany(t => t.Commentaires).Where(c => c.IdCommentaire == id).First();
                return commentaire;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Commentaire> FindAll()
        {
            var commentaires = TitleFactory.CreateTitles().SelectMany(t => t.Commentaires);

            return commentaires;
        }
    }
}


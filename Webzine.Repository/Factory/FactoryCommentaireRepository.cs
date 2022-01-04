using System;
using Webzine.Entity;
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
            throw new NotImplementedException();
        }

        public Commentaire Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Commentaire> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}


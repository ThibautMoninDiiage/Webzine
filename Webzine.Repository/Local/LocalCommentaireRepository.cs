using System;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Local
{
    public class LocalCommentaireRepository : ICommentaireRepository
    {
        public LocalCommentaireRepository()
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


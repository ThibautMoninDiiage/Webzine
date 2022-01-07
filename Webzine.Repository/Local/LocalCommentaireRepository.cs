using Microsoft.EntityFrameworkCore;
using System;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Local
{
    public class LocalCommentaireRepository : ICommentaireRepository
    {
        private readonly WebzineDbContext _webzineDbContext;

        public LocalCommentaireRepository()
        {
            _webzineDbContext = new WebzineDbContext();
        }

        public void Add(Commentaire commentaire)
        {
            _webzineDbContext.Commentaires.Add(commentaire);
            _webzineDbContext.SaveChanges();
        }

        public void Delete(Commentaire commentaire)
        {
            _webzineDbContext.Commentaires.Remove(commentaire);
            _webzineDbContext.SaveChanges();
        }

        public Commentaire Find(int id)
        {
            return _webzineDbContext.Commentaires.Find(id);
        }

        public IEnumerable<Commentaire> FindAll()
        {
            return _webzineDbContext.Commentaires.Include(c => c.Titre).ToList();
        }
    }
}


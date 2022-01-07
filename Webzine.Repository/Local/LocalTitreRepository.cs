using System;
using Webzine.Entity;
using Webzine.Repository.Contracts;
using Webzine.EntitiesContext;

namespace Webzine.Repository.Local
{
    public class LocalTitreRepository : ITitreRepository
    {
        private readonly WebzineDbContext _webzineDbContext;

        public LocalTitreRepository()
        {
            _webzineDbContext = new WebzineDbContext();
        }

        public void AddTitre(Titre titre)
        {
            titre.UrlEcoute = "";
            titre.UrlJaquette = "";
            _webzineDbContext.Add(titre);
            _webzineDbContext.SaveChanges();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void DeleteTitre(Titre titre)
        {
            throw new NotImplementedException();
        }

        public Titre Find(int idTitre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Titre> FindAll()
        {
            return _webzineDbContext.Titres.ToList();
        }

        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public void IncrementNbLectures(Titre titre)
        {
            throw new NotImplementedException();
        }

        public void IncrementNbLikes(Titre titre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            throw new NotImplementedException();
        }

        public void Update(Titre titre)
        {
            throw new NotImplementedException();
        }
    }
}


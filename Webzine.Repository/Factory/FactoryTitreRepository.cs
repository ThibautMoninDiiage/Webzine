using System;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Factory
{
    public class FactoryTitreRepository : ITitreRepository
    {
        public FactoryTitreRepository()
        {
        }

        public void AddTitre(Titre titre)
        {
        }

        public int Count()
        {
            return 0;
        }

        public void DeleteTitre(Titre titre)
        {
        }

        public Titre Find(int idTitre)
        {
            return TitleFactory.CreateTitles().Where(t => t.IdTitre == idTitre).FirstOrDefault();
        }

        public IEnumerable<Titre> FindAll()
        {
            throw new NotImplementedException();
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


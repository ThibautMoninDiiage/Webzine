using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

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
            titre.Artiste = _webzineDbContext.Artistes.Find(titre.IdArtiste);
            titre.TitresStyles = _webzineDbContext.Styles.Where(s => titre.TitresStyles.Contains(s)).ToList();


            _webzineDbContext.Add(titre);
            _webzineDbContext.SaveChanges();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void DeleteTitre(Titre titre)
        {
            _webzineDbContext.Remove(titre);
            _webzineDbContext.SaveChanges();
        }

        public Titre Find(int idTitre)
        {
            var titre = _webzineDbContext.Titres
                .Include(t => t.Artiste)
                .Include(t => t.TitresStyles)
                .Include(t => t.Commentaires)
                .Where(t => t.IdTitre == idTitre)
                .FirstOrDefault();

            return titre;
        }

        public IEnumerable<Titre> FindAll()
        {
            return _webzineDbContext.Titres.Include(t => t.Artiste).Include(t => t.TitresStyles).ToList();
        }

        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public void IncrementNbLectures(Titre titre)
        {
            titre.NbLectures++;
            _webzineDbContext.Update(titre);
            _webzineDbContext.SaveChanges();
        }

        public void IncrementNbLikes(Titre titre)
        {
            titre.NbLikes++;
            _webzineDbContext.Update(titre);
            _webzineDbContext.SaveChanges();
        }

        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            throw new NotImplementedException();
        }

        public void Update(Titre titre)
        {
            _webzineDbContext.Update(titre);
            _webzineDbContext.SaveChanges();
        }
    }
}


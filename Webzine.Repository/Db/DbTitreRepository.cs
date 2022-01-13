using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Db
{
    public class DbTitreRepository : ITitreRepository
    {
        private readonly WebzineDbContext _webzineDbContext;

        public DbTitreRepository()
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
            return _webzineDbContext.Titres.Count();
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
            return _webzineDbContext.Titres.Include(t => t.Artiste).Include(t => t.TitresStyles).Include(t => t.Commentaires).ToList();
        }

        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            return _webzineDbContext.Titres.OrderBy(t => t.DateCreation).Skip(offset).Take(limit);
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
            List<Titre> titres = _webzineDbContext.Titres.Include(t => t.TitresStyles).Where(t => t.TitresStyles.Any(s => s.Libelle == libelle)).ToList();
            return titres;
        }

        public void Update(Titre titre)
        {
            _webzineDbContext.Update(titre);
            _webzineDbContext.SaveChanges();
        }
    }
}


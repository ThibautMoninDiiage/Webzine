using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Local
{
    public class LocalTitreRepository : ITitreRepository
    {
        public LocalTitreRepository()
        {
        }

        public void AddTitre(Titre titre)
        {
        }

        public int Count()
        {
            return TitleFactory.CreateTitles().Count();
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
            return TitleFactory.CreateTitles().OrderBy(titre => titre.Artiste.Nom);
        }

        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            return TitleFactory.CreateTitles().OrderBy(t => t.DateCreation).Skip(offset).Take(limit);
        }

        public void IncrementNbLectures(Titre titre)
        {
           
        }

        public void IncrementNbLikes(Titre titre)
        {
        }

        public IEnumerable<Titre> SearchByStyle(string libelle)
        {
            return TitleFactory.CreateTitles().Where(t => t.TitresStyles.Any(s => s.Libelle == libelle)).ToList();
        }

        public void Update(Titre titre)
        {
        }
    }
}


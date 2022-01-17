using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Db
{
    public class DbCommentaireRepository : ICommentaireRepository
    {
        private readonly WebzineDbContext _webzineDbContext;

        public DbCommentaireRepository(WebzineDbContext context)
        {
            _webzineDbContext = context;
        }

        public void Add(Commentaire commentaire)
        {
            commentaire.Titre = _webzineDbContext.Titres.Find(commentaire.IdTitre);
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
            return _webzineDbContext.Commentaires.Include(c => c.Titre).ThenInclude(t => t.Artiste).FirstOrDefault(c => c.IdCommentaire == id);
        }

        public IEnumerable<Commentaire> FindAll()
        {
            return _webzineDbContext.Commentaires.Include(commentaire => commentaire.Titre).ThenInclude(titre => titre.Artiste).ToList();
        }
    }
}

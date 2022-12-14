using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Db
{
    public class DbStyleRepository : IStyleRepository
    {
        private readonly WebzineDbContext _webzineDbContext;
        public DbStyleRepository(WebzineDbContext context)
        {
            _webzineDbContext = context;
        }

        public void Add(Style style)
        {
            _webzineDbContext.Add<Style>(style);
            _webzineDbContext.SaveChanges();
        }

        public void Delete(Style style)
        {
            _webzineDbContext.Styles.Remove(style);
            _webzineDbContext.SaveChanges();

        }

        public Style Find(int id)
        {
            var style = _webzineDbContext.Styles.Find(id);
            style.TitresStyles = _webzineDbContext.Titres.Include(t => t.Artiste).Where(t => t.TitresStyles.Contains(style)).ToList();
            return style;

        }

        public IEnumerable<Style> FindAll()
        {
            return _webzineDbContext.Styles.OrderBy(style => style.Libelle).ToList();
        }

        public void Update(Style style)
        {
            _webzineDbContext.Update(style);
            _webzineDbContext.SaveChanges();
        }
    }
}


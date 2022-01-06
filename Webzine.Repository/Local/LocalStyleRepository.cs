using System;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Local
{
    public class LocalStyleRepository : IStyleRepository
    {
        private readonly WebzineDbContext _webzineDbContext;
        public LocalStyleRepository()
        {
            _webzineDbContext = new WebzineDbContext();
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
            return _webzineDbContext.Styles.Find(id);

        }

        public IEnumerable<Style> FindAll()
        {
            return _webzineDbContext.Styles.ToList();
        }

        public void Update(Style style)
        {
            throw new NotImplementedException();
        }
    }
}


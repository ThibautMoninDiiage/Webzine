using System;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Factory
{
    public class FactoryStyleRepository : IStyleRepository
    {
        public FactoryStyleRepository()
        {
        }

        public void Add(Style style)
        {
            throw new NotImplementedException();
        }

        public void Delete(Style style)
        {
            throw new NotImplementedException();
        }

        public Style Find(int id)
        {
            var style = StyleFactory.CreateStyles().Where(s => s.IdStyle == id).FirstOrDefault();
            style.TitresStyles = TitleFactory.CreateTitles().Where(t => t.TitresStyles.Any(s => s.IdStyle == id)).ToList();

            return style;
        }

        public IEnumerable<Style> FindAll()
        {
            return StyleFactory.CreateStyles();
        }

        public void Update(Style style)
        {
            throw new NotImplementedException();
        }
    }
}


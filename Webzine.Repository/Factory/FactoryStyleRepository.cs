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
        }

        public void Delete(Style style)
        {
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
        }
    }
}


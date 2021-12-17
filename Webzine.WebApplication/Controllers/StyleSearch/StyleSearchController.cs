using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.StyleSearch
{
    public class StyleSearchController : Controller
    {
        public IEnumerable<Titre> Titles => TitleFactory.CreateTitles();
        public Style Style { get; set; }

        public IActionResult Index(string styleId)
        {
            this.Style = StyleFactory.CreateStyles().Where(s => s.IdStyle.ToString() == styleId).First();
            var model = new StyleSearchViewModel()
            {
                Style = this.Style,
                Titles = this.Titles.Where(t => t.TitresStyles.Any(s => s.IdStyle.ToString() == styleId)).ToList()
            };

            return this.View(model);
        }
    }
}

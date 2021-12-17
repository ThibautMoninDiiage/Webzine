using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.StyleSearch
{
    public class StyleSearchController : Controller
    {
        public IEnumerable<Titre> Titles => TitleFactory.CreateTitles();

        public IActionResult Index(string styleId)
        {
            var model = new StyleSearchViewModel()
            {
                Titles = this.Titles.ToList(),
                Style = StyleFactory.CreateStyles().Where(s => s.IdStyle.ToString() == styleId).First()
            };

            return this.View(model);
        }
    }
}

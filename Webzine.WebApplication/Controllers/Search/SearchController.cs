using Microsoft.AspNetCore.Mvc;
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Contact
{
    public class SearchController : Controller
    {
        public IActionResult Index(string keyword)
        {
            var model = new SearchViewModel
            {
                Keyword = keyword,
                Artistes = ArtistFactory.CreateArtists().Where(a => a.Nom.Contains(keyword)),
                Titres = TitleFactory.CreateTitles().Where(t => t.Libelle.Contains(keyword))
            };

            return this.View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Contact
{
    public class RechercheController : Controller
    {
        public IActionResult Index(string keyword = "")
        {
            if (!String.IsNullOrWhiteSpace(keyword) || !String.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
            } else
            {
                keyword = "";
            }

            var model = new SearchViewModel
            {
                Keyword = keyword,
                Artistes = ArtistFactory.CreateArtists().Where(a => a.Nom.ToLower().Contains(keyword)),
                Titres = TitleFactory.CreateTitles().Where(t => t.Libelle.ToLower().Contains(keyword))
            };

            return this.View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Contact
{
    public class RechercheController : Controller
    {
        private readonly ILogger<RechercheController> _logger;
        public RechercheController(ILogger<RechercheController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string keyword = "")
        {
            _logger.LogInformation("L'utilisateur recherche un mot clé.");

            if (!String.IsNullOrWhiteSpace(keyword) || !String.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
            }
            else
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

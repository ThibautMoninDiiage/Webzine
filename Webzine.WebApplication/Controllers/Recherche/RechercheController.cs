using Microsoft.AspNetCore.Mvc;
using Webzine.Business.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Contact
{
    public class RechercheController : Controller
    {
        private readonly ILogger<RechercheController> _logger;
        private readonly IRechercheService _rechercheService;


        public RechercheController(ILogger<RechercheController> logger, IRechercheService rechercheService)
        {
            _logger = logger;
            _rechercheService = rechercheService;
        }

        public IActionResult Index(string keyword = "")
        {

            if (keyword == null)
            {
                keyword = "";
            }

            var model = new SearchViewModel
            {
                Artistes = _rechercheService.RechercherArtiste(keyword),
                Titres = _rechercheService.RechercherTitre(keyword),
                Keyword = keyword
            };

            return this.View(model);
        }
    }
}

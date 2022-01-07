using Microsoft.AspNetCore.Mvc;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Contact
{
    public class RechercheController : Controller
    {
        private readonly ILogger<RechercheController> _logger;
        private readonly IArtisteRepository _artisteRepository;
        private readonly ITitreRepository _titreRepository;
        public RechercheController(ILogger<RechercheController> logger, IArtisteRepository artisteRepository, ITitreRepository titreRepository)
        {
            _logger = logger;
            _artisteRepository = artisteRepository;
            _titreRepository = titreRepository;
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
                Artistes = _artisteRepository.FindAll().Where(a => a.Nom.ToLower().Contains(keyword)),
                Titres = _titreRepository.FindAll().Where(t => t.Libelle.ToLower().Contains(keyword))
            };

            return this.View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.StyleSearch
{
    public class StyleSearchController : Controller
    {
        private readonly ILogger<StyleSearchController> _logger;
        private readonly IStyleRepository _styleRepository;

        public StyleSearchController(IStyleRepository styleRepository, ILogger<StyleSearchController> logger)
        {
            _styleRepository = styleRepository;
            _logger = logger;
        }

        public IActionResult Index(int styleId)
        {
            _logger.LogInformation("L'utilisateur fait une recherche de styles.");

            var model = new StyleSearchViewModel()
            {
                Style = _styleRepository.Find(styleId)
            };

            return this.View(model);
        }
    }
}

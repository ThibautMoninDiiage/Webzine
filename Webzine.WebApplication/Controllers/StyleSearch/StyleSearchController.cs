using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.StyleSearch
{
    public class StyleSearchController : Controller
    {
        private IStyleRepository _styleRepository;

        public StyleSearchController(IStyleRepository styleRepository)
        {
            _styleRepository = styleRepository;
        }

        public IActionResult Index(int styleId)
        {

            var model = new StyleSearchViewModel()
            {
                Style = _styleRepository.Find(styleId)
            };

            return this.View(model);
        }
    }
}

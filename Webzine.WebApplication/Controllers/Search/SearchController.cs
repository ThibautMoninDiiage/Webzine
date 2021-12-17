using Microsoft.AspNetCore.Mvc;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Contact
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            var model = new SearchViewModel();

            return this.View(model);
        }
    }
}

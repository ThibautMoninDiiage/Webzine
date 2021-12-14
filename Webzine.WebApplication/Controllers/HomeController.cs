using Microsoft.AspNetCore.Mvc;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Styles = "Jazz"
            };

            return this.View(model);
        }
    }
}

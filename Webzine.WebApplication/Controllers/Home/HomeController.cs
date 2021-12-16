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
                Styles = new List<string> { "Jazz", "Rap", "Zumba", "Rock", "Electro", "Country", "Classique" }
            };

            ViewBag.Styles = new List<string> { "Jazz", "Rap", "Zumba", "Rock", "Electro", "Country", "Classique" };

            return this.View(model);
        }
    }
}

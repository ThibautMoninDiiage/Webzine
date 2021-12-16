using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IEnumerable<Style> Styles => HomeFactory.CreateStyles();
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Styles = this.Styles.ToList()
            };

            ViewBag.Styles = this.Styles.ToList();

            return this.View(model);
        }
    }
}

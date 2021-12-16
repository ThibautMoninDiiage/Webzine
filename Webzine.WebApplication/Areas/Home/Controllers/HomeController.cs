using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    [Area("Home")]
    [Route("home")]
    public class HomeController : Controller
    {
        public HomeController()
        {
            // do stuff
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Artist()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Title()
        {
            return View();
        }
    }
}

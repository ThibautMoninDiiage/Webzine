using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        public AdminController()
        {
            // do stuff
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Createedit()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}

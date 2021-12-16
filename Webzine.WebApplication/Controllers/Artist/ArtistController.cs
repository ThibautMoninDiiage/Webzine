using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers.Artist
{
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

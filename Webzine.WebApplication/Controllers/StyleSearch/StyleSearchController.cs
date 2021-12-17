using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers.StyleSearch
{
    public class StyleSearchController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

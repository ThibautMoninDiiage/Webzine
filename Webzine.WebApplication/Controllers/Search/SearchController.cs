using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers.Contact
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

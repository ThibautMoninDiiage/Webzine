using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers.Contact
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Contact
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            var model = new ContactViewModel();

            return this.View(model);
        }
    }
}

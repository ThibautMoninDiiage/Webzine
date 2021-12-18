using System;
using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Style
{
    [Area("Admin")]
    public class StyleController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View("Create");
        }

        public IActionResult Delete()
        {

            return this.View("Delete");
        }
    }
}


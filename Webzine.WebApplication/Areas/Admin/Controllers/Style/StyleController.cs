using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity.Factory;
using Webzine.WebApplication.Areas.Admin.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Style
{
    [Area("Admin")]
    public class StyleController : Controller
    {
        public IActionResult Index()
        {
            var model = new StyleViewModel
            {
                Styles = StyleFactory.CreateStyles()
            };

            return this.View(model);
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


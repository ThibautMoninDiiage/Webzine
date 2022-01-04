using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity.Factory;
using Webzine.WebApplication.Areas.Admin.ViewModels;
using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Style
{
    [Area("Administration")]
    public class StyleController : Controller
    {
        private IEnumerable<Entity.Style> _styles => StyleFactory.CreateStyles();

        public IActionResult Index()
        {
            var model = new StyleViewModel
            {
                Styles = this._styles
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


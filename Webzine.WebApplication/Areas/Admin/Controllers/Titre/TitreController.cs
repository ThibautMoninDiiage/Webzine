using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity.Factory;
using Webzine.WebApplication.Areas.Admin.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Title
{
    [Area("Admin")]
    public class TitreController : Controller
    {
        private IEnumerable<Entity.Style> _styles => StyleFactory.CreateStyles();
        private IEnumerable<Entity.Titre> _titres => TitleFactory.CreateTitles();

        public IActionResult Index()
        {
            var model = new TitleViewModel
            {
                Titres = this._titres
            };
            return this.View(model);
        }


        public IActionResult Create()
        {
            var model = new TitleViewModel
            {
                Styles = _styles
            };

            return this.View("Create", model);
        }


        public IActionResult Delete()
        {
            return this.View("Delete");
        }
    }
}

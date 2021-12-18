using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity.Factory;
using Webzine.WebApplication.Areas.Admin.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Title
{
    [Area("Admin")]
    public class TitleController : Controller
    {

        public IActionResult Index()
        {
            var model = new TitleViewModel
            {
                Titres = TitleFactory.CreateTitles()
            };
            return this.View(model);
        }


        public IActionResult Create()
        {
            var model = new TitleViewModel
            {
                Styles = StyleFactory.CreateStyles()
            };

            return this.View("Create", model);
        }


        public IActionResult Delete()
        {
            return this.View("Delete");
        }
    }
}


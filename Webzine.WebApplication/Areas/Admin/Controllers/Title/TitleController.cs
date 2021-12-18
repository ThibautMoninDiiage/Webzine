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
    }
}


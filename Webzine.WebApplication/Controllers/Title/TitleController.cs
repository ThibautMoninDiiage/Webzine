using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Title
{
    public class TitleController : Controller
    {
        public IActionResult Index(int IdTitre)
        {
            var model = new TitleViewModel()
            {
                Titre = TitleFactory.CreateTitles().Where(t => t.IdTitre == IdTitre).FirstOrDefault()
            };

            return this.View(model);
        }
    }
}

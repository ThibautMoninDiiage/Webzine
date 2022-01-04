using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Title
{
    public class TitreController : Controller
    {
        private ITitreRepository _titreRepository;

        public TitreController(ITitreRepository titreRepository)
        {
            this._titreRepository = titreRepository;
        }

        public IActionResult Index(int idTitre)
        {
            var model = new TitleViewModel()
            {
                Titre = _titreRepository.Find(idTitre)
            };

            return this.View(model);
        }
    }
}

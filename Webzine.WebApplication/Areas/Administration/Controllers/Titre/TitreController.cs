using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.Areas.Admin.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Title
{
    [Area("Administration")]
    public class TitreController : Controller
    {
        private ITitreRepository _titreRepository;
        private IStyleRepository _styleRepository;


        public TitreController(ITitreRepository titreRepository, IStyleRepository styleRepository)
        {
            _titreRepository = titreRepository;
            _styleRepository = styleRepository;
        }

        public IActionResult Index()
        {
            var model = new TitleViewModel
            {
                Titres = _titreRepository.FindAll()
            };
            return this.View(model);
        }


        public IActionResult Create()
        {
            var model = new TitleViewModel
            {
                Styles = _styleRepository.FindAll()
            };

            return this.View("Create", model);
        }


        public IActionResult Delete()
        {
            return this.View("Delete");
        }
    }
}

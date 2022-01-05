using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.WebApplication.Areas.Admin.ViewModels;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Style
{
    [Area("Administration")]
    public class StyleController : Controller
    {
        private IStyleRepository _styleRepository;


        public StyleController(IStyleRepository styleRepository)
        {
            _styleRepository = styleRepository;
        }

        public IActionResult Index()
        {
            var model = new StyleViewModel
            {
                Styles = _styleRepository.FindAll()
            };

            return this.View("Index", model);
        }

        public IActionResult Create()
        {
            return this.View("Create");
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreatePost(string libelle)
        {
            _styleRepository.Add(new Entity.Style() { Libelle = libelle });
            return Index();
        }

        public IActionResult Edit(int idStyle)
        {
            var model = new StyleViewModel
            {
                Style = _styleRepository.Find(idStyle)
            };

            return this.View("Create", model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditPost(int idStyle, string libelle)
        {
            _styleRepository.Update(new Entity.Style() {IdStyle = idStyle, Libelle = libelle });
            return Index();
        }

        public IActionResult Delete(int idStyle)
        {
            var model = new StyleViewModel
            {
                Style = _styleRepository.Find(idStyle)
            };
            return this.View("Delete", model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int idStyle)
        {
            _styleRepository.Delete(new Entity.Style() { IdStyle = idStyle });

            return Index();
        }
    }
}


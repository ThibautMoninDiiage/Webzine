using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.Areas.Admin.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Style
{
    [Area("Administration")]
    public class StyleController : Controller
    {
        private readonly IStyleRepository _styleRepository;
        private const String regex = @"^[/*_]*$";

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
            bool regexMatch = Regex.IsMatch(libelle, regex);
            if (regexMatch == true)
            {
                ModelState.AddModelError(string.Empty, libelle + " contient des caractères non valides !");
            }
            if (_styleRepository.FindAll().Any(styleRepo => styleRepo.Libelle == libelle))
            {
                ModelState.AddModelError(string.Empty, libelle + " existe déjà !");
            }
            if (this.ModelState.IsValid)
            {
                _styleRepository.Add(new Entity.Style() { Libelle = libelle });
                return Index();
            }
            return Create();

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
            if (this.ModelState.IsValid)
            {
                _styleRepository.Update(new Entity.Style() { IdStyle = idStyle, Libelle = libelle });
                return Index();
            }
            return Edit(idStyle);
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


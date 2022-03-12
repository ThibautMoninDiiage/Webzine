using Microsoft.AspNetCore.Mvc;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.Areas.Admin.ViewModels;
using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Admin.Controllers//.Style
{
    [Area("Administration")]
    public class StyleController : Controller
    {
        private readonly IStyleRepository _styleRepository;

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
        public IActionResult CreatePost(Style style)
        {
            if (this.ModelState.IsValid)
            {
                _styleRepository.Add(new Entity.Style() { Libelle = style.Libelle });
                return Index();
            }
            if (_styleRepository.FindAll().Any(styleRepo => styleRepo.Libelle == style.Libelle))
            {
                ModelState.AddModelError(string.Empty, style + " existe déjà !");
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
        public IActionResult EditPost(Style style)
        {
            if (this.ModelState.IsValid)
            {
                _styleRepository.Update(style);
                return Index();
            }
            return Edit(style.IdStyle);
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
        public IActionResult DeletePost(Style style)
        {
            
            //MessageBox.Show("Are you sure to delete this style?", "Delete Style", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            //case MessageBoxResult.Yes:
            _styleRepository.Delete(style);
            //      break;
			//case MessageBoxResult.No:
            //      break;
            return Index();
        }
    }
}


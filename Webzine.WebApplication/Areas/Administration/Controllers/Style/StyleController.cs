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


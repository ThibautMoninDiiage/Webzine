﻿using Microsoft.AspNetCore.Mvc;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.StyleSearch
{
    public class StyleSearchController : Controller
    {
        private readonly ILogger<StyleSearchController> _logger;
        private readonly IStyleRepository _styleRepository;

        public StyleSearchController(IStyleRepository styleRepository, ILogger<StyleSearchController> logger)
        {
            _styleRepository = styleRepository;
            _logger = logger;
        }

        public IActionResult Index(string libelle)
        {
            _logger.LogInformation("L'utilisateur fait une recherche de styles.");

            var style = _styleRepository.FindAll().Where(style => style.Libelle == libelle).FirstOrDefault();

            var model = new StyleSearchViewModel()
            {
                Style = _styleRepository.Find(style.IdStyle)
            };

            return this.View(model);
        }
    }
}

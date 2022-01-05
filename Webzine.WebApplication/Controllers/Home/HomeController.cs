using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using System.Linq; // Import Linq
using Webzine.WebApplication.ViewModels;
using Webzine.Repository.Contracts;

namespace Webzine.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IEnumerable<Titre> AllTitles => _titreRepository.FindAll();
        public IEnumerable<Titre> MostPopularTitles => AllTitles.OrderByDescending(t => t.NbLikes).Take(3);
        public IEnumerable<Titre> OrderedTitles { get; set; }
        private ITitreRepository _titreRepository;


        public HomeController(ITitreRepository titreRepository, ILogger<HomeController> logger)
        {
            _titreRepository = titreRepository;
            _logger = logger;
        }

        public IActionResult Index(bool isLastReleased = true)
        {
            _logger.LogInformation("Accès à la page d'accueil.");

            if (isLastReleased)
            {
                OrderedTitles = AllTitles.OrderByDescending(t => t.DateCreation).Take(3);
            } else
            {
                OrderedTitles = AllTitles.OrderBy(t => t.DateCreation).Take(3);
            }

            var model = new HomeViewModel
            {
                MostPopularTitles = this.MostPopularTitles,
                OrderedTitles = this.OrderedTitles,
                IsLastReleased = isLastReleased
            };

            return this.View(model);
        }
    }
}

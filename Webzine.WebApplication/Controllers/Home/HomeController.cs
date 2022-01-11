using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITitreRepository _titreRepository;
        private int numberOfTitlePerPages = 3;


        public HomeController(ITitreRepository titreRepository, ILogger<HomeController> logger)
        {
            _titreRepository = titreRepository;
            _logger = logger;
        }

        public IActionResult Index(int numeroPage = 1)
        {
            _logger.LogInformation("Accès à la page d'accueil.");


            int numberOfPage = _titreRepository.Count() / numberOfTitlePerPages;


            if (!(_titreRepository.Count() % numberOfTitlePerPages == 0))
            {
                numberOfPage++;
            }

            if(numeroPage < 1 || numeroPage > numberOfPage)
            {
                numeroPage = 1;
            }


            var orderedTitles = _titreRepository.FindTitres((numeroPage - 1) * numberOfTitlePerPages, numberOfTitlePerPages);


            var model = new HomeViewModel
            {
                MostPopularTitles = _titreRepository.FindAll().OrderByDescending(t => t.NbLikes).Take(3),
                OrderedTitles = orderedTitles,
                NumberOfTitles = _titreRepository.Count(),
                NumberOfTitlePerPages = numberOfTitlePerPages,
                CurrentPage = numeroPage,
                NumberOfPages = numberOfPage
            };

            return this.View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITitreRepository _titreRepository;
        private readonly IConfiguration _configuration;
        private readonly int _numberOfTitlePerPages;


        public HomeController(ITitreRepository titreRepository, ILogger<HomeController> logger, IConfiguration configuration)
        {
            _titreRepository = titreRepository;
            _logger = logger;
            _configuration = configuration;
            _numberOfTitlePerPages = Int32.Parse(_configuration["numberOfTitlePerPages"]);
        }

        public IActionResult Index(int numeroPage = 1)
        {
            _logger.LogInformation("Accès à la page d'accueil.");


            int numberOfPage = _titreRepository.Count() / _numberOfTitlePerPages;


            if (!(_titreRepository.Count() % _numberOfTitlePerPages == 0))
            {
                numberOfPage++;
            }

            if(numeroPage < 1 || numeroPage > numberOfPage)
            {
                numeroPage = 1;
            }


            var orderedTitles = _titreRepository.FindTitres((numeroPage - 1) * _numberOfTitlePerPages, _numberOfTitlePerPages);


            var model = new HomeViewModel
            {
                MostPopularTitles = _titreRepository.FindAll().OrderByDescending(t => t.NbLikes).Take(3),
                OrderedTitles = orderedTitles,
                NumberOfTitles = _titreRepository.Count(),
                NumberOfTitlePerPages = _numberOfTitlePerPages,
                CurrentPage = numeroPage,
                NumberOfPages = numberOfPage
            };

            return this.View(model);
        }
    }
}

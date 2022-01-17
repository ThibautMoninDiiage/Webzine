using Microsoft.AspNetCore.Mvc;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.Areas.Administration.ViewModels;

namespace Webzine.WebApplication.Areas.Administration.Controllers.Dashboard
{

    [Area("Administration")]
    public class DashboardController : Controller
    {
        private readonly IArtisteRepository _artisteRepository;
        private readonly ITitreRepository _titreRepository;
        private readonly IStyleRepository _styleRepository;

        public DashboardController(IArtisteRepository artisteRepository, ITitreRepository titreRepository, IStyleRepository styleRepository)
        {
            _artisteRepository = artisteRepository;
            _titreRepository = titreRepository;
            _styleRepository = styleRepository;
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                NbArtistes = _artisteRepository.FindAll().Count(), // ok
                ArtistePlusChronique = _artisteRepository.FindAll().OrderByDescending(a => a.Titres.Sum(t => t.NbLectures)).FirstOrDefault(), // ok
                ArtistePlusTitreAlbumsDistincts = _artisteRepository.FindAll().OrderByDescending(a => a.Titres.Select(t => t.Album).Distinct().Count()).FirstOrDefault(),
                NbBiographies = _artisteRepository.FindAll().Select(a => a.Biographie).Where(b => !string.IsNullOrEmpty(b)).Count(), // ok
                TitreLePlusVu = _titreRepository.FindAll().OrderByDescending(titre => titre.NbLectures).FirstOrDefault(), // ok
                NbTitres = _titreRepository.Count(), // ok
                NbStyles = _styleRepository.FindAll().Count(), // ok
                NbLectures = _titreRepository.FindAll().Sum(t => t.NbLectures), // ok
                NbLikes = _titreRepository.FindAll().Sum(t => t.NbLikes) //ok 
            };

            return this.View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Title
{
    public class TitreController : Controller
    {
        private readonly ILogger<TitreController> _logger;
        private ITitreRepository _titreRepository;

        public TitreController(ITitreRepository titreRepository, ILogger<TitreController> logger)
        {
            this._titreRepository = titreRepository;
            _logger = logger;
        }

        public IActionResult Index(int idTitre)
        {
            _logger.LogInformation("Accès à la page titre.");
            var titre = _titreRepository.Find(idTitre);
            _titreRepository.IncrementNbLectures(titre);

            var model = new TitleViewModel()
            {
                Titre = _titreRepository.Find(idTitre)
            };

            return this.View("Index", model);
        }

        [HttpPost]
        public IActionResult Liker(int idTitre)
        {
            var titre = _titreRepository.Find(idTitre);
            _titreRepository.IncrementNbLikes(titre);

            return this.Index(idTitre);
        }

    }
}

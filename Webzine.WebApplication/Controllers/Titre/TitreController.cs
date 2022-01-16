using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Title
{
    public class TitreController : Controller
    {
        private readonly ILogger<TitreController> _logger;
        private readonly ITitreRepository _titreRepository;
        private readonly ICommentaireRepository _commentaireRepository;


        public TitreController(ITitreRepository titreRepository, ICommentaireRepository commentaireRepository, ILogger<TitreController> logger)
        {
            _commentaireRepository = commentaireRepository;
            _titreRepository = titreRepository;
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

        [HttpPost]
        public IActionResult Commenter(int idTitre, string nom, string contenu)
        {
            var commentaire = new Commentaire()
            {
                Auteur = nom,
                Contenu = contenu,
                DateCreation = DateTime.Now,
                IdTitre = idTitre
            };

            if (this.ModelState.IsValid)
            {
                _commentaireRepository.Add(commentaire);
                return this.Index(idTitre);
            }
            return this.Index(idTitre);
        }

    }
}

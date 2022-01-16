using Microsoft.AspNetCore.Mvc;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.Areas.Admin.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Titre
{
    [Area("Administration")]
    public class TitreController : Controller
    {
        private readonly ITitreRepository _titreRepository;
        private readonly IStyleRepository _styleRepository;
        private readonly IArtisteRepository _artisteRepository;


        public TitreController(ITitreRepository titreRepository, IStyleRepository styleRepository, IArtisteRepository artisteRepository)
        {
            _titreRepository = titreRepository;
            _styleRepository = styleRepository;
            _artisteRepository = artisteRepository;
        }

        public IActionResult Index()
        {
            var model = new TitleViewModel
            {
                Titres = _titreRepository.FindAll()
            };
            return this.View("Index", model);
        }


        public IActionResult Create()
        {
            var model = new TitleViewModel
            {
                Styles = _styleRepository.FindAll(),
                Artistes = _artisteRepository.FindAll()
            };

            return this.View("Create", model);
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreatePost(int idArtiste, string nomTitre, string nomAlbum, string chronique, DateTime datesortie, int duree, List<int> idStyles, string urlJaquette, string urlEcoute)
        {
            var titre = new Entity.Titre()
            {
                IdArtiste = idArtiste,
                Libelle = nomTitre,
                Album = nomAlbum,
                Chronique = chronique,
                DateSortie = datesortie,
                DateCreation = DateTime.Now,
                Duree = duree,
                UrlJaquette = urlJaquette,
                UrlEcoute = urlEcoute,
                TitresStyles = _styleRepository.FindAll().Where(s => idStyles.Contains(s.IdStyle)).ToList()
            };



            if (this.ModelState.IsValid)
            {
                _titreRepository.AddTitre(titre);
                return Index();
            }
            return Create();
        }

        public IActionResult Edit(int idTitre)
        {
            var model = new TitleViewModel
            {
                Styles = _styleRepository.FindAll(),
                Artistes = _artisteRepository.FindAll(),
                Titre = _titreRepository.Find(idTitre)
            };
            return this.View("Create", model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditPost(int idTitre, int idArtiste, string nomTitre, string nomAlbum, string chronique, DateTime datesortie, int duree, List<int> idStyles, string urlJaquette, string urlEcoute)
        {
            var titre = new Entity.Titre()
            {
                IdTitre = idTitre,
                IdArtiste = idArtiste,
                Artiste = _artisteRepository.Find(idArtiste),
                Libelle = nomTitre,
                Album = nomAlbum,
                Chronique = chronique,
                DateSortie = datesortie,
                UrlJaquette = urlJaquette,
                UrlEcoute = urlEcoute,
                Duree = duree,
                TitresStyles = _styleRepository.FindAll().Where(s => idStyles.Contains(s.IdStyle)).ToList(),
            };

            if (this.ModelState.IsValid)
            {
                _titreRepository.Update(titre);
                return Index();
            }
            return Edit(idTitre);
        }


        public IActionResult Delete(int idTitre)
        {
            var titre = _titreRepository.Find(idTitre);
            var model = new TitleViewModel
            {
                Titre = titre
            };
            return this.View("Delete", model);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int idTitre)
        {
            _titreRepository.DeleteTitre(new Entity.Titre { IdTitre = idTitre });
            return Index();
        }
    }
}

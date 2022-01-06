using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.Areas.Admin.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Titre
{
    [Area("Administration")]
    public class TitreController : Controller
    {
        private ITitreRepository _titreRepository;
        private IStyleRepository _styleRepository;
        private IArtisteRepository _artisteRepository;


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
        public IActionResult CreatePost(int idArtiste, string nomTitre, string nomAlbum, string chronique, DateTime datesortie, int duree, List<int> idStyles)
        {
            var titre = new Entity.Titre()
            {
                IdArtiste = idArtiste,
                Artiste = _artisteRepository.Find(idArtiste),
                Libelle = nomTitre,
                Album = nomAlbum,
                Chronique = chronique,
                DateSortie = datesortie,
                DateCreation = DateTime.Now,
                Duree = duree,
                TitresStyles = _styleRepository.FindAll().Where(s => idStyles.Contains(s.IdStyle)).ToList()
            };

            _titreRepository.AddTitre(titre);

            return Index();
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
        public IActionResult EditPost(int idTitre, int idArtiste, string nomTitre, string nomAlbum, string chronique, DateTime datesortie, int duree, List<int> idStyles)
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
                Duree = duree,
                TitresStyles = _styleRepository.FindAll().Where(s => idStyles.Contains(s.IdStyle)).ToList(),
            };

            _titreRepository.Update(titre);

            return Index();
        }


        public IActionResult Delete()
        {
            return this.View("Delete");
        }
    }
}

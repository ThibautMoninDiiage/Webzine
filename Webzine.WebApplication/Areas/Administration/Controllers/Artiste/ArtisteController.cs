using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.Areas.Admin.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Artist
{

    [Area("Administration")]
    public class ArtisteController : Controller
    {
        private IArtisteRepository _artisteRepository;

        public ArtisteController(IArtisteRepository artisteRepository)
        {
            _artisteRepository = artisteRepository;
        }


        public IActionResult Index()
        {
            var model = new ArtistViewModel
            {
                Artistes = _artisteRepository.FindAll()
            };

            return this.View("Index", model);
        }


        public IActionResult Create()
        {
            return this.View("Create");
        }


        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreatePost(string nom, string biographie)
        {
            var artiste = new Artiste() { Nom = nom, Biographie = biographie };


            if (this.ModelState.IsValid)
            {
                _artisteRepository.AddArtiste(artiste);
                return Index(); // redirect to index page
            }
            return Create();
        }

        public IActionResult Edit(int idArtiste)
        {
            var artiste = _artisteRepository.Find(idArtiste);

            if (artiste == null)
            {
                return this.View("Create");
            }
            else
            {
                var model = new ArtistViewModel
                {
                    Artiste = artiste
                };
                return this.View("Create", model);
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditPost(int idArtiste, string nom, string biographie)
        {
            var artiste = new Artiste() { IdArtiste = idArtiste, Nom = nom, Biographie = biographie, UrlSite = "" };
            if (this.ModelState.IsValid)
            {
                _artisteRepository.UpdateArtiste(artiste);
                return Index();
            }
            return Edit(idArtiste);
        }

        public IActionResult Delete(int idArtiste)
        {
            var artiste = _artisteRepository.Find(idArtiste);

            var model = new ArtistViewModel
            {
                Artiste = artiste
            };

            return this.View("Delete", model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int idArtiste)
        {
            _artisteRepository.DeleteArtiste(new Artiste { IdArtiste = idArtiste });
            return Index();
        }
    }
}

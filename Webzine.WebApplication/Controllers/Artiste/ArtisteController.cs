using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class ArtisteController : Controller
    {
        private Artiste _artiste;
        public IEnumerable<Style> Styles => StyleFactory.CreateStyles();
        public IArtisteRepository _artisteRepository;


        public ArtisteController(IArtisteRepository artisteRepository)
        {
            _artisteRepository = artisteRepository;
        }

        public IActionResult Index(int IdArtiste)
        {
            this._artiste = _artisteRepository.Find(IdArtiste);

            var model = new ArtistViewModel
            {
                Artist = this._artiste
            };

            return this.View(model);
        }
    }


}


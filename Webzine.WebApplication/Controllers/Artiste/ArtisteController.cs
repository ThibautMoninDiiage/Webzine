using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class ArtisteController : Controller
    {
        private Artiste _artiste;
        public IEnumerable<Style> Styles => StyleFactory.CreateStyles(); 

        public IActionResult Index(int IdArtiste)
        {
            this._artiste = ArtistFactory.GetArtist(IdArtiste);

            var model = new ArtistViewModel
            {
                Artist = this._artiste
            };

            return this.View(model);
        }
    }


}


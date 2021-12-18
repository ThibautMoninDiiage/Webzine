using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class ArtistController : Controller
    {
        private Artiste Artist;
        public IEnumerable<Style> Styles => StyleFactory.CreateStyles(); 

        public IActionResult Index(int IdArtiste)
        {
            this.Artist = ArtistFactory.GetArtist(IdArtiste);

            var model = new ArtistViewModel
            {
                Artist = this.Artist
            };

            return this.View(model);
        }
    }


}


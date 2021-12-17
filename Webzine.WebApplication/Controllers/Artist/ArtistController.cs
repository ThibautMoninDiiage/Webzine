using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class ArtistController : Controller
    {
        public Artiste Artist => ArtistFactory.GetArtiste();
        public IEnumerable<Style> Styles => StyleFactory.CreateStyles(); 

        public IActionResult Index()
        {
            var model = new ArtistViewModel
            {
                Artist = this.Artist
            };


            return this.View(model);
        }
    }
}


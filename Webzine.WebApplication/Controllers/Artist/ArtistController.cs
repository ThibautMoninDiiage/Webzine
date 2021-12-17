using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class ArtistController : Controller
    {
        public Artiste Artist => ArtistFactory.GetArtist();
        public IEnumerable<Style> Styles => StyleFactory.CreateStyles(); 

        public IActionResult Index()
        {
           

            var model = new ArtistViewModel
            {
                Artist = this.Artist
            };

            ViewBag.Styles = this.Styles.ToList();
            return this.View(model);
        }
    }


}


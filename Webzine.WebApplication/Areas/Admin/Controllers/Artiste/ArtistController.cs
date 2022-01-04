using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.WebApplication.Areas.Admin.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Artist
{

    [Area("Admin")]
    public class ArtisteController : Controller
    {
        private IEnumerable<Artiste> _artistes => ArtistFactory.CreateArtists();

        public IActionResult Index()
        {
            var model = new ArtistViewModel
            {
                Artistes = this._artistes
            };

            return this.View(model);
        }


        public IActionResult Create()
        {
            return this.View("Create");
        }

        public IActionResult Delete()
        {
            return this.View("Delete");
        }


    }
}


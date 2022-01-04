using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
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


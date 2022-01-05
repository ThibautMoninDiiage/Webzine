﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Edit(int idArtiste)
        {
            var artiste = _artisteRepository.Find(idArtiste);

            if(artiste == null)
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

        public IActionResult Delete(int idArtiste)
        {
            var artiste = _artisteRepository.Find(idArtiste);

            var model = new ArtistViewModel
            {
                Artiste = artiste
            };

            return this.View("Delete", model);
        }


    }
}


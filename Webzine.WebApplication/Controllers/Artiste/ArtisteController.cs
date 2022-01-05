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
        private readonly ILogger<ArtisteController> _logger;
        private Artiste _artiste;
        public IEnumerable<Style> Styles => StyleFactory.CreateStyles();
        public IArtisteRepository _artisteRepository;
        
        public ArtisteController(IArtisteRepository artisteRepository, ILogger<ArtisteController> logger)
        {
            _artisteRepository = artisteRepository;
            _logger = logger;
        }

        public IActionResult Index(int IdArtiste)
        {
            _logger.LogInformation("Accès à la page artiste.");

            this._artiste = _artisteRepository.Find(IdArtiste);

            var model = new ArtistViewModel
            {
                Artist = this._artiste
            };

            return this.View(model);
        }
    }
}

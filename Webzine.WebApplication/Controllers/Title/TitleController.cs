using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers.Title
{
    public class TitleController : Controller
    {
        public IActionResult Index()
        {
            var model = new TitleViewModel()
            {
                IdTitle = 1,
                Name = "Papillon",
                Chronique = "Ceci est la chronique du titre Papillon de l'artiste Zola",
                DateCreation = DateTime.Now,
                NbLikes = 139821,
                TitresStyles = new List<Style>() {
                    new Style() { IdStyle = 1, Libelle = "Jazz" },
                    new Style() { IdStyle = 2, Libelle = "Rap" }
                },
                Libelle = "Papillon",
                Artiste = new Artiste() { Nom = "Zola" },
                UrlJaquette = "https://static.fnac-static.com/multimedia/Images/FR/NR/08/c5/c2/12764424/1540-1/tsp20201019142053/Survie.jpg"
            };

            return this.View(model);
        }
    }
}

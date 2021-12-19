using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using System.Linq; // Import Linq
using Webzine.Entity.Factory;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IEnumerable<Titre> MostPopularTitles => TitleFactory.CreateTitles().OrderByDescending(t => t.NbLikes).Take(3);
        public IEnumerable<Titre> AllTitles => TitleFactory.CreateTitles();
        public IEnumerable<Titre> OrderedTitles { get; set; }

        public IActionResult Index(bool isLastReleased = true)
        {

            if (isLastReleased)
            {
                OrderedTitles = AllTitles.OrderByDescending(t => t.DateCreation).Take(3);
            } else
            {
                OrderedTitles = AllTitles.OrderBy(t => t.DateCreation).Take(3);
            }

            var model = new HomeViewModel
            {
                MostPopularTitles = this.MostPopularTitles,
                OrderedTitles = this.OrderedTitles,
                IsLastReleased = isLastReleased
            };

            return this.View(model);
        }
    }
}

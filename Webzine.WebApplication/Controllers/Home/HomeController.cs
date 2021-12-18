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
        public IEnumerable<Titre> LastReleasedTitles => TitleFactory.CreateTitles().OrderByDescending(t => t.DateCreation).Take(3);

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                MostPopularTitles = this.MostPopularTitles.ToList(),
                LastReleasedTitles = this.LastReleasedTitles.ToList()
            };

            return this.View(model);
        }
    }
}

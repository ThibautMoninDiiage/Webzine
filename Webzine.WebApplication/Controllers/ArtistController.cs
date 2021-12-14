using System;
using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers
{
    public class ArtistController : Controller
    {
        public ArtistController()
        {
        }


        public IActionResult Index()
        {
            return this.View();
        }
    }
}


using System;
using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers
{
    public class TitleController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}


﻿using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

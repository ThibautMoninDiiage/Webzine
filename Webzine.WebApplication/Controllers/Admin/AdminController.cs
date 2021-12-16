using System;
using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}


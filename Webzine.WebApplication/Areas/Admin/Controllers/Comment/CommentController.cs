using System;
using Microsoft.AspNetCore.Mvc;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Comment
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Delete()
        {
            return this.View("Delete");
        }
    }
}


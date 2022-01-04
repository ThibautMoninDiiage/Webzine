using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.WebApplication.Areas.Admin.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Comment
{
    [Area("Admin")]
    public class CommentaireController : Controller
    {
        public IActionResult Index()
        {
            var model = new CommentViewModel
            {
                Commentaires = new List<Commentaire>() { new Commentaire { Auteur = "Drizzy", Contenu = "Bien", DateCreation = DateTime.Now, IdCommentaire = 1, IdTitre = 1, Titre = TitleFactory.CreateTitles().First() } }
            };

            return this.View(model);
        }

        public IActionResult Delete()
        {
            return this.View("Delete");
        }
    }
}

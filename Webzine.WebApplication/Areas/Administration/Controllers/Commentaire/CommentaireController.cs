using System;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.Areas.Admin.ViewModels;

namespace Webzine.WebApplication.Areas.Admin.Controllers.Comment
{
    [Area("Administration")]
    public class CommentaireController : Controller
    {
        private ICommentaireRepository _commentaireRepository;

        public CommentaireController(ICommentaireRepository commentaireRepository)
        {
            _commentaireRepository = commentaireRepository;
        }

        public IActionResult Index()
        {
            var model = new CommentViewModel
            {
                Commentaires = _commentaireRepository.FindAll()
            };

            return this.View(model);
        }

        public IActionResult Delete(int idCommentaire)
        {
            var commentaire = _commentaireRepository.Find(idCommentaire);

            var model = new CommentViewModel
            {
                Commentaire = commentaire
            };

            return this.View("Delete", model);
        }
    }
}

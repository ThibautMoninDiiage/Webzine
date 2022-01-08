using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
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

            return this.View("Index", model);
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


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int idCommentaire)
        {
            _commentaireRepository.Delete(new Commentaire() { IdCommentaire = idCommentaire });

            return Index();
        }
    }
}

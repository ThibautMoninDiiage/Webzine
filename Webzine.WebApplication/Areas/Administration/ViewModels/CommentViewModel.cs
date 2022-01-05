using System;
using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    public class CommentViewModel
    {
        public IEnumerable<Commentaire> Commentaires { get; set; }
        public Commentaire Commentaire { get; set; }

    }
}

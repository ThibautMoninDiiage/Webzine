using Webzine.Entity;

namespace Webzine.WebApplication.ViewModels
{
    public class TitleViewModel : BaseViewModel
    {
        public Titre Titre { get; set; }
        public Commentaire Commentaire { get; set; }
    }
}

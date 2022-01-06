using Webzine.Entity;

namespace Webzine.WebApplication.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public string Keyword { get; set; }
        public IEnumerable<Titre> Titres { get; set; }
        public IEnumerable<Artiste> Artistes { get; set; }
    }
}


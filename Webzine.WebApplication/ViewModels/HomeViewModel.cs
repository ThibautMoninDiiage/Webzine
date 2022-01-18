using Webzine.Entity;

namespace Webzine.WebApplication.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public IEnumerable<Titre> MostPopularTitles { get; set; }
        public IEnumerable<Titre> OrderedTitles { get; set; }
        public int NumberOfTitles { get; set; }
        public int CurrentPage { get; set; }
        public int NumberOfTitlePerPages { get; set; }
        public int NumberOfPages { get; set; }

    }
}

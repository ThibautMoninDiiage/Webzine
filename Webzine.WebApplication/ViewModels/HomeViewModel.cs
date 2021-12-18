using System;
using Webzine.Entity;

namespace Webzine.WebApplication.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public IEnumerable<Titre> MostPopularTitles { get; set; }
        public IEnumerable<Titre> LastReleasedTitles { get; set; }
    }
}

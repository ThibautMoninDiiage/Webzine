using System;
using Webzine.Entity;

namespace Webzine.WebApplication.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Style> Styles { get; set; }

        public IEnumerable<Titre> MostPopularTitles { get; set; }
        public IEnumerable<Titre> LastReleasedTitles { get; set; }
    }
}

using System;
using Webzine.Entity;

namespace Webzine.WebApplication.ViewModels
{
    public class StyleSearchViewModel : BaseViewModel
    {
        public IEnumerable<Titre> Titles { get; set; }
        public Style Style { get; set; }
    }
}


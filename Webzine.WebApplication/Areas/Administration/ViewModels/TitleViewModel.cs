using System;
using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    public class TitleViewModel
    {
        public IEnumerable<Titre> Titres { get; set; }
        public IEnumerable<Style> Styles { get; set; }
        public IEnumerable<Artiste> Artistes { get; set; }
        public Titre Titre { get; set; }
    }
}


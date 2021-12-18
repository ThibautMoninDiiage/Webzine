using System;
using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    public class TitleViewModel
    {
        public IEnumerable<Titre> Titres { get; set; }
    }
}


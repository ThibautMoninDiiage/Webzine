using System;
using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    public class StyleViewModel
    {
        public IEnumerable<Style> Styles { get; set; }
        public Style Style { get; set; }
    }
}


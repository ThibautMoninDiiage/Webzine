using System;
using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Admin.ViewModels
{
    public class ArtistViewModel
    {
        public IEnumerable<Artiste> Artistes { get; set; }
    }
}


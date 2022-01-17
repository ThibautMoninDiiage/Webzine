using Webzine.Entity;

namespace Webzine.WebApplication.Areas.Administration.ViewModels
{
    public class DashboardViewModel
    {
        public int NbArtistes { get; set; }
        public Artiste ArtistePlusChronique { get; set; }
        public Artiste ArtistePlusTitreAlbumsDistincts { get; set; }
        public int NbBiographies { get; set; }
        public Titre TitreLePlusVu { get; set; }
        public int NbTitres { get; set; }
        public int NbStyles { get; set; }
        public long NbLectures { get; set; }
        public long NbLikes { get; set; }
    }
}

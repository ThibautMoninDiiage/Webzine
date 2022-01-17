using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Webzine.Entity;

namespace Webzine.EntitiesContext
{
    // Cette classe définit le contexte de la base de données
    // Les entités correspondent aux tables dans la base de données
    public class WebzineDbContext : DbContext
    {
        public DbSet<Titre> Titres { get; set; }
        public DbSet<Artiste> Artistes { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Style> Styles { get; set; }

        // Le constructeur défini le chemin d'accès de création de la base de données "locale"
        public WebzineDbContext(DbContextOptions<WebzineDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}

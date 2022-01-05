using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webzine.Entity;

namespace Webzine.EntitiesContext
{
    // Cette classe définit le contexte de la base de données
    // Les entités correspondent aux tables dans la base de données
    public class WebzineDbContext : DbContext
    {
        public DbSet<Artiste>? Artistes { get; set; }
        public DbSet<Commentaire>? Commentaires { get; set; }
        public DbSet<Style>? Styles { get; set; }
        public DbSet<Titre>? Titres { get; set; }

        public WebzineDbContext()
        {

        }

        // Le constructeur défini le chemin d'accès de création de la base de données "locale"
        public WebzineDbContext(DbContextOptions<WebzineDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=Webzine.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artiste>(entity =>
            {
                entity.ToTable("ARTISTE");
                entity.Property(e => e.IdArtiste).HasColumnName("Id");
                entity.Property(e => e.Nom).HasColumnName("Nom");
                entity.Property(e => e.Biographie).HasColumnName("Biographie");
                // entity.Property(e => e.Titres).HasColumnName("Titre");
                entity.Property(e => e.DateNaissance).HasColumnName("DateNaissance");
                entity.Property(e => e.UrlSite).HasColumnName("UrlSite");
            });
        }

    }
}

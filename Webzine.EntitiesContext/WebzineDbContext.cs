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
                // Défini le nom de la table dans la base de données
                entity.ToTable("ARTISTE");
                // Défini le nom des champs dans la base de données
                entity.Property(e => e.IdArtiste).HasColumnName("Id");
                entity.Property(e => e.Nom).HasColumnName("Nom");
                entity.Property(e => e.Biographie).HasColumnName("Biographie");
                entity.Property(e => e.Titres).HasColumnName("Titre");
                entity.Property(e => e.DateNaissance).HasColumnName("DateNaissance");
                entity.Property(e => e.UrlSite).HasColumnName("UrlSite");
            });

            modelBuilder.Entity<Commentaire>(entity =>
            {
                entity.ToTable("COMMENTAIRE");
                entity.Property(e => e.IdCommentaire).HasColumnName("Id");
                entity.Property(e => e.Contenu).HasColumnName("Contenu");
                entity.Property(e => e.Auteur).HasColumnName("Auteur");
                entity.Property(e => e.DateCreation).HasColumnName("DateCreation");
                entity.Property(e => e.IdTitre).HasColumnName("IdTitre");
                entity.Property(e => e.Titre).HasColumnName("Titre");
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.ToTable("STYLE");
                entity.Property(e => e.IdStyle).HasColumnName("Id");
                entity.Property(e => e.Libelle).HasColumnName("Libelle");
                entity.Property(e => e.TitresStyles).HasColumnName("TitresStyles");
            });

            modelBuilder.Entity<Titre>(entity =>
            {
                entity.ToTable("TITRE");
                entity.Property(e => e.IdTitre).HasColumnName("Id");
                entity.Property(e => e.IdArtiste).HasColumnName("IdArtiste");
                entity.Property(e => e.Artiste).HasColumnName("Artiste");
                entity.Property(e => e.Libelle).HasColumnName("Libelle");
                entity.Property(e => e.Chronique).HasColumnName("Chronique");
                entity.Property(e => e.DateCreation).HasColumnName("DateCreation");
                entity.Property(e => e.Duree).HasColumnName("Duree");
                entity.Property(e => e.DateSortie).HasColumnName("DateSortie");
                entity.Property(e => e.UrlJaquette).HasColumnName("UrlJaquette");
                entity.Property(e => e.UrlEcoute).HasColumnName("UrlEcoute");
                entity.Property(e => e.NbLectures).HasColumnName("NbLectures");
                entity.Property(e => e.NbLikes).HasColumnName("NbLikes");
                entity.Property(e => e.Album).HasColumnName("Album");
                entity.Property(e => e.TitresStyles).HasColumnName("TitresStyles");
                entity.Property(e => e.Commentaires).HasColumnName("Commentaires");
            });

        }

    }
}

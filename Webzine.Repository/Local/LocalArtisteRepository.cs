﻿using System;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Local
{
    public class LocalArtisteRepository : IArtisteRepository
    {
        private readonly WebzineDbContext _webzineDbContext;

        public LocalArtisteRepository()
        {
            _webzineDbContext = new WebzineDbContext();
        }

        public void AddArtiste(Artiste artiste)
        {
            artiste.UrlSite = "";
            _webzineDbContext.Add(artiste);
            _webzineDbContext.SaveChanges();
        }

        public void DeleteArtiste(Artiste artiste)
        {
            _webzineDbContext.Remove(artiste);
            _webzineDbContext.SaveChanges();
        }

        public Artiste Find(int id)
        {
            return _webzineDbContext.Artistes.Find(id);
        }

        public IEnumerable<Artiste> FindAll()
        {
            return _webzineDbContext.Artistes.ToList();
        }

        public void UpdateArtiste(Artiste artiste)
        {
            _webzineDbContext.Update(artiste);
            _webzineDbContext.SaveChanges();
        }
    }
}

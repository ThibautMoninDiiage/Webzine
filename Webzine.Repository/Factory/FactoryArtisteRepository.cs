using System;
using System.Collections.Generic;
using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Factory
{
    public class FactoryArtisteRepository : IArtisteRepository
    {
        public FactoryArtisteRepository() 
        {
        }

        public void AddArtiste(Artiste artiste)
        {
            
        }

        public void DeleteArtiste(Artiste artiste)
        {
            
        }

        public Artiste Find(int id)
        {
            var artiste = ArtistFactory.CreateArtists().Where(a => a.IdArtiste == id).FirstOrDefault();

            return artiste;
        }

        public IEnumerable<Artiste> FindAll()
        {
            return ArtistFactory.CreateArtists(); 
        }

        public void UpdateArtiste(Artiste artiste)
        {
        }
    }
}


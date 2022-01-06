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
            var artiste = ArtistFactory.GetArtist(id);

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


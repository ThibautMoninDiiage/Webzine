using Webzine.Entity;
using Webzine.Entity.Factory;
using Webzine.Repository.Contracts;

namespace Webzine.Repository.Local
{
    public class LocalArtisteRepository : IArtisteRepository
    {
        public LocalArtisteRepository()
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
            return ArtistFactory.CreateArtists().OrderBy(a => a.Nom);
        }

        public void UpdateArtiste(Artiste artiste)
        {
        }
    }
}


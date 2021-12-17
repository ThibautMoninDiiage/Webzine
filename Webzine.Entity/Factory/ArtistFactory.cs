using System;
namespace Webzine.Entity.Factory
{
    public class ArtistFactory
    {
        public static IEnumerable<Artiste> CreateArtists()
        {
            List<Artiste> artists = new List<Artiste>();

            Artiste artiste1 = new Artiste() { Nom = "Zola", IdArtiste = 1, Titres = new List<Titre>(), DateNaissance = new DateTime(1999, 11, 16), UrlSite = "https://fr.wikipedia.org/wiki/Zola_(rappeur)", Biographie = "Zola Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            Artiste artiste2 = new Artiste() { Nom = "Tengo John", IdArtiste = 2, Titres = new List<Titre>(), DateNaissance = new DateTime(1999, 11, 16), UrlSite = "https://fr.wikipedia.org/wiki/Zola_(rappeur)", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            Artiste artiste3 = new Artiste() { Nom = "Damso", IdArtiste = 3, Titres = new List<Titre>(), DateNaissance = new DateTime(1999, 11, 16), UrlSite = "https://fr.wikipedia.org/wiki/Zola_(rappeur)", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };

            artists.Add(artiste1);
            artists.Add(artiste2);
            artists.Add(artiste3);

            return artists;
        }


        public static Artiste GetArtist()
        {
            Artiste artist = new Artiste() { Nom = "Zola", IdArtiste = 1, Titres = new List<Titre>(), DateNaissance = new DateTime(1999, 11, 16), UrlSite = "https://fr.wikipedia.org/wiki/Zola_(rappeur)", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };

            artist.Titres = TitleFactory.CreateTitles().Where(t => t.IdArtiste == artist.IdArtiste).ToList();


            return artist;
        }
    }
}


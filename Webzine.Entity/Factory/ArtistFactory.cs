namespace Webzine.Entity.Factory
{
    public class ArtistFactory
    {
        public static IEnumerable<Artiste> CreateArtists()
        {
            List<Artiste> artists = new List<Artiste>();

            Artiste artiste1 = new Artiste() { Nom = "Zola", IdArtiste = 1, Titres = new List<Titre>(), DateNaissance = new DateTime(1999, 11, 16), UrlSite = "https://fr.wikipedia.org/wiki/Zola_(rappeur)", Biographie = "Zola Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            Artiste artiste2 = new Artiste() { Nom = "Tengo John", IdArtiste = 2, Titres = new List<Titre>(), DateNaissance = new DateTime(1995, 5, 1), UrlSite = "https://rapologie.fr/tengo-john#:~:text=Tengo%20John%20est%20un%20rappeur,rap%20va%20continuer%20de%20grandir.", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            Artiste artiste3 = new Artiste() { Nom = "Damso", IdArtiste = 3, Titres = new List<Titre>(), DateNaissance = new DateTime(1982, 6, 1), UrlSite = "https://fr.wikipedia.org/wiki/Damso", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            Artiste artiste4 = new Artiste() { Nom = "SDM", IdArtiste = 4, Titres = new List<Titre>(), DateNaissance = new DateTime(1982, 6, 1), UrlSite = "https://fr.wikipedia.org/wiki/Damso", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            Artiste artiste5 = new Artiste() { Nom = "Orelsan", IdArtiste = 5, Titres = new List<Titre>(), DateNaissance = new DateTime(1982, 6, 1), UrlSite = "https://fr.wikipedia.org/wiki/Damso", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            Artiste artiste6 = new Artiste() { Nom = "Jul", IdArtiste = 6, Titres = new List<Titre>(), DateNaissance = new DateTime(1982, 6, 1), UrlSite = "https://fr.wikipedia.org/wiki/Damso", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            Artiste artiste7 = new Artiste() { Nom = "Timal", IdArtiste = 7, Titres = new List<Titre>(), DateNaissance = new DateTime(1982, 6, 1), UrlSite = "https://fr.wikipedia.org/wiki/Damso", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            Artiste artiste8 = new Artiste() { Nom = "Booba", IdArtiste = 8, Titres = new List<Titre>(), DateNaissance = new DateTime(1982, 6, 1), UrlSite = "https://fr.wikipedia.org/wiki/Damso", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            Artiste artiste9 = new Artiste() { Nom = "Kaaris", IdArtiste = 9, Titres = new List<Titre>(), DateNaissance = new DateTime(1982, 6, 1), UrlSite = "https://fr.wikipedia.org/wiki/Damso", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            Artiste artiste10 = new Artiste() { Nom = "Kekra", IdArtiste = 10, Titres = new List<Titre>(), DateNaissance = new DateTime(1982, 6, 1), UrlSite = "https://fr.wikipedia.org/wiki/Damso", Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };

            artists.Add(artiste1);
            artists.Add(artiste2);
            artists.Add(artiste3);
            artists.Add(artiste4);
            artists.Add(artiste5);
            artists.Add(artiste6);
            artists.Add(artiste7);
            artists.Add(artiste8);
            artists.Add(artiste9);
            artists.Add(artiste10);

            return artists;
        }

        public static Artiste GetArtist(int IdArtiste)
        {
            try
            {
                Artiste artist = CreateArtists().Where(a => a.IdArtiste == IdArtiste).FirstOrDefault();

                artist.Titres = TitleFactory.CreateTitles().Where(t => t.IdArtiste == artist.IdArtiste).ToList();


                return artist;
            }
            catch
            {
                return null;
            }
        }
    }
}


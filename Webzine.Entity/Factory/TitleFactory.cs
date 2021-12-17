using System;
namespace Webzine.Entity.Factory
{
    public class TitleFactory
    {
        public static IEnumerable<Titre> CreateTitles()
        {
            List<Artiste> artists = ArtistFactory.CreateArtists().ToList(); // Generate artists
            List<Titre> titles = new List<Titre>(); // init the listof all artists

            Titre papillon = new Titre() {
                IdTitre = 1,
                IdArtiste = artists[0].IdArtiste,
                Artiste = artists[0],
                Album = "Survie",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2020, 12, 17),
                DateSortie = new DateTime(2020, 11, 19),
                Duree = 123,
                Libelle = "Papillon",
                NbLikes = 37651,
                NbLectures = 99328,
                TitresStyles = StyleFactory.CreateStyles(3).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=diSQuucDoBA",
                UrlJaquette = "https://static.fnac-static.com/multimedia/Images/FR/NR/08/c5/c2/12764424/1540-1/tsp20201019142053/Survie.jpg", Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };
            artists[0].Titres.Add(papillon);
            titles.Add(papillon);


            Titre troisSabresZero = new Titre
            {
                IdTitre = 2,
                IdArtiste = artists[1].IdArtiste,
                Artiste = artists[1],
                Album = "Trois sabres zéro",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2021, 12, 15),
                DateSortie = new DateTime(2021, 10, 30),
                Duree = 349,
                Libelle = "Trois sabres zéro",
                NbLikes = 1200,
                NbLectures = 3070,
                TitresStyles = StyleFactory.CreateStyles(1).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=vMM_Es3tB0U",
                UrlJaquette = "https://images.genius.com/7947a8e0e74c950a435d781098bf9bab.1000x1000x1.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };
            artists[1].Titres.Add(troisSabresZero);
            titles.Add(troisSabresZero);


            Titre macarena = new Titre
            {
                IdTitre = 3,
                IdArtiste = artists[2].IdArtiste,
                Artiste = artists[2],
                Album = "Ipséité",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2021, 12, 13),
                DateSortie = new DateTime(2017, 7, 6),
                Duree = 206,
                Libelle = "Macarena",
                NbLikes = 17901,
                NbLectures = 76964,
                TitresStyles = StyleFactory.CreateStyles(5).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=GGhKPm18E48",
                UrlJaquette = "https://m.media-amazon.com/images/I/61yWfxvZfGL._SL1400_.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };

            artists[2].Titres.Add(macarena);
            titles.Add(macarena);

            return titles;
        }
    }
}


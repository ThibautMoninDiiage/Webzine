namespace Webzine.Entity.Factory
{
    public class TitleFactory
    {
        public static IEnumerable<Titre> CreateTitles()
        {
            List<Artiste> artists = ArtistFactory.CreateArtists().ToList(); // Generate artists
            List<Titre> titles = new List<Titre>(); // init the listof all artists
            List<Style> styles = StyleFactory.CreateStyles().ToList();

            Titre papillon = new Titre()
            {
                IdTitre = 1,
                IdArtiste = artists[0].IdArtiste,
                Artiste = artists[0],
                Album = "Survie",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2020, 12, 17),
                DateSortie = new DateTime(2020, 11, 19),
                Duree = 123,
                Libelle = "Papillon",
                NbLikes = 20,
                NbLectures = 100,
                TitresStyles = styles.Where(s => s.IdStyle == 1 || s.IdStyle == 3).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=diSQuucDoBA",
                UrlJaquette = "https://static.fnac-static.com/multimedia/Images/FR/NR/08/c5/c2/12764424/1540-1/tsp20201019142053/Survie.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and oui oui oui"
            };

            papillon.Commentaires.Add(
                new Commentaire() { Auteur = "Drizzy", Contenu = "Le son est super.", DateCreation = DateTime.Now, IdTitre = 1, IdCommentaire = 1, Titre = papillon }
                );


            artists[0].Titres.Add(papillon);
            titles.Add(papillon);

            Titre broBro = new Titre()
            {
                IdTitre = 4,
                IdArtiste = artists[0].IdArtiste,
                Artiste = artists[0],
                Album = "Survie",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2020, 12, 17),
                DateSortie = new DateTime(2020, 11, 19),
                Duree = 173,
                Libelle = "Bro Bro",
                NbLikes = 10,
                NbLectures = 50,
                TitresStyles = styles.Where(s => s.IdStyle == 1 || s.IdStyle == 3).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=dIA8yFCGjl0",
                UrlJaquette = "https://static.fnac-static.com/multimedia/Images/FR/NR/08/c5/c2/12764424/1540-1/tsp20201019142053/Survie.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };
            artists[0].Titres.Add(broBro);
            titles.Add(broBro);

            Titre papers = new Titre()
            {
                IdTitre = 5,
                IdArtiste = artists[0].IdArtiste,
                Artiste = artists[0],
                Album = "Cicatrices",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2019, 12, 17),
                DateSortie = new DateTime(2019, 4, 5),
                Duree = 203,
                Libelle = "Papers",
                NbLikes = 15,
                NbLectures = 40,
                TitresStyles = styles.Where(s => s.IdStyle == 1 || s.IdStyle == 3).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=RrLUlS17GrI",
                UrlJaquette = "https://m.media-amazon.com/images/I/81HLWg0lpJL._SL1500_.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };
            artists[0].Titres.Add(papers);
            titles.Add(papers);


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
                NbLikes = 100,
                NbLectures = 400,
                TitresStyles = styles.Where(s => s.IdStyle == 1 || s.IdStyle == 3 || s.IdStyle == 8).ToList(),
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
                NbLikes = 250,
                NbLectures = 600,
                TitresStyles = styles.Where(s => s.IdStyle == 7 || s.IdStyle == 10).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=GGhKPm18E48",
                UrlJaquette = "https://m.media-amazon.com/images/I/61yWfxvZfGL._SL1400_.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };

            artists[2].Titres.Add(macarena);
            titles.Add(macarena);

            Titre radio = new Titre
            {
                IdTitre = 6,
                IdArtiste = artists[3].IdArtiste,
                Artiste = artists[3],
                Album = "Ocho",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2021, 12, 13),
                DateSortie = new DateTime(2017, 7, 6),
                Duree = 206,
                Libelle = "Radio",
                NbLikes = 250,
                NbLectures = 600,
                TitresStyles = styles.Where(s => s.IdStyle == 7 || s.IdStyle == 10).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=GGhKPm18E48",
                UrlJaquette = "https://static.fnac-static.com/multimedia/Images/FR/NR/8c/72/d4/13922956/1540-1/tsp20211122143208/OCHO.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };

            artists[3].Titres.Add(radio);
            titles.Add(radio);

            Titre basique = new Titre
            {
                IdTitre = 7,
                IdArtiste = artists[4].IdArtiste,
                Artiste = artists[4],
                Album = "La fête est finie",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2021, 12, 13),
                DateSortie = new DateTime(2017, 7, 6),
                Duree = 206,
                Libelle = "Basique",
                NbLikes = 250,
                NbLectures = 600,
                TitresStyles = styles.Where(s => s.IdStyle == 7 || s.IdStyle == 10).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=GGhKPm18E48",
                UrlJaquette = "https://e.snmc.io/i/1200/s/34770dbf57d09c5481de096dbe30a39c/7236249",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };

            artists[4].Titres.Add(basique);
            titles.Add(basique);

            Titre ovni = new Titre
            {
                IdTitre = 8,
                IdArtiste = artists[5].IdArtiste,
                Artiste = artists[5],
                Album = "L'Ovni",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2021, 12, 13),
                DateSortie = new DateTime(2017, 7, 6),
                Duree = 206,
                Libelle = "Ovni",
                NbLikes = 250,
                NbLectures = 600,
                TitresStyles = styles.Where(s => s.IdStyle == 7 || s.IdStyle == 10).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=GGhKPm18E48",
                UrlJaquette = "https://static.fnac-static.com/multimedia/Images/FR/NR/32/3f/78/7880498/1540-1/tsp20161108104246/L-Ovni.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };

            artists[5].Titres.Add(ovni);
            titles.Add(ovni);

            Titre fuego = new Titre
            {
                IdTitre = 9,
                IdArtiste = artists[6].IdArtiste,
                Artiste = artists[6],
                Album = "Arès",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2021, 12, 13),
                DateSortie = new DateTime(2017, 7, 6),
                Duree = 206,
                Libelle = "Fuego",
                NbLikes = 250,
                NbLectures = 600,
                TitresStyles = styles.Where(s => s.IdStyle == 7 || s.IdStyle == 10).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=GGhKPm18E48",
                UrlJaquette = "https://static.fnac-static.com/multimedia/Images/FR/NR/b7/67/d2/13789111/1507-1/tsp20210929161334/Ares.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };

            artists[6].Titres.Add(fuego);
            titles.Add(fuego);

            Titre bonnejournee = new Titre
            {
                IdTitre = 10,
                IdArtiste = artists[7].IdArtiste,
                Artiste = artists[7],
                Album = "Ultra",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2020, 12, 13),
                DateSortie = new DateTime(2019, 9, 6),
                Duree = 206,
                Libelle = "Bonne journée",
                NbLikes = 250,
                NbLectures = 600,
                TitresStyles = styles.Where(s => s.IdStyle == 7 || s.IdStyle == 10).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=GGhKPm18E48",
                UrlJaquette = "https://www.raprnb.com/wp-content/uploads/2021/03/0b8290c44d2de7466237e6797139a5f3-1000x1000x1.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };

            artists[7].Titres.Add(bonnejournee);
            titles.Add(bonnejournee);

            Titre goulag = new Titre
            {
                IdTitre = 11,
                IdArtiste = artists[8].IdArtiste,
                Artiste = artists[8],
                Album = "Chateau Noir",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2021, 10, 14),
                DateSortie = new DateTime(2018, 7, 6),
                Duree = 206,
                Libelle = "Goulag",
                NbLikes = 2504,
                NbLectures = 6500,
                TitresStyles = styles.Where(s => s.IdStyle == 7 || s.IdStyle == 10).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=GGhKPm18E48",
                UrlJaquette = "https://static.fnac-static.com/multimedia/Images/FR/NR/dd/61/cb/13328861/1540-1/tsp20210311160158/Nouvel-album.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };

            artists[8].Titres.Add(goulag);
            titles.Add(goulag);

            Titre numero9 = new Titre
            {
                IdTitre = 12,
                IdArtiste = artists[9].IdArtiste,
                Artiste = artists[9],
                Album = "K.E.K.R.A",
                Commentaires = new List<Commentaire>(),
                DateCreation = new DateTime(2022, 01, 09),
                DateSortie = new DateTime(2020, 7, 6),
                Duree = 206,
                Libelle = "Numéro 9",
                NbLikes = 2500,
                NbLectures = 9000,
                TitresStyles = styles.Where(s => s.IdStyle == 7 || s.IdStyle == 10).ToList(),
                UrlEcoute = "https://www.youtube.com/watch?v=GGhKPm18E48",
                UrlJaquette = "https://static.qobuz.com/images/covers/rb/1c/o7i2h0r3f1crb_600.jpg",
                Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            };

            artists[9].Titres.Add(numero9);
            titles.Add(numero9);

            return titles;
        }

    }
}

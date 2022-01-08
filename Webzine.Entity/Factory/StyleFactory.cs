namespace Webzine.Entity.Factory
{
    public class StyleFactory
    {
        public static IEnumerable<Style> CreateStyles()
        {
            return new List<Style>()
            {
                new Style(){ IdStyle = 1, Libelle = "Rap" },
                new Style(){ IdStyle = 2, Libelle = "Rock" },
                new Style(){ IdStyle = 3, Libelle = "Pop" },
                new Style(){ IdStyle = 4, Libelle = "Classique" },
                new Style(){ IdStyle = 5, Libelle = "Americain" },
                new Style(){ IdStyle = 6, Libelle = "K-POP" },
                new Style(){ IdStyle = 7, Libelle = "Electro" },
                new Style(){ IdStyle = 8, Libelle = "New" },
                new Style(){ IdStyle = 9, Libelle = "Gabon" },
                new Style(){ IdStyle = 10, Libelle = "Jazz" }
            };
        }

        public static IEnumerable<Style> GetStyles(int numberOfStyles)
        {
            Random random = new Random();

            return CreateStyles().ToList().OrderBy(s => random.Next()).Take(3);
        }

    }
}

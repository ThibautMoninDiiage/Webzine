namespace Webzine.Entity.Interfaces
{
    public interface IArtiste
    {
        public int IdArtiste { get; set; }
        public string Nom { get; set; }
        public string Biographie { get; set; }
        public List<Titre> Titres { get; set; }
        public DateTime DateNaissance { get; set; }
        public string UrlSite { get; set; }
    }
}

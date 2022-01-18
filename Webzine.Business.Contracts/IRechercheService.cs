using Webzine.Entity;

namespace Webzine.Business.Contracts
{
    public interface IRechercheService
    {
        /// <summary>
        /// Méthode qui permet de rechercher un artiste dans la base de données
        /// </summary>
        /// <param name="keyword">Nom de l'artiste</param>
        /// <returns>La liste d'artiste correspondant au mot clé</returns>
        IEnumerable<Titre> RechercherTitre(string keyword = "");

        /// <summary>
        /// Méthode qui permet de rechercher un titre dans la base de données
        /// </summary>
        /// <param name="keyword">Nom du titre</param>
        /// <returns>La liste de titre correspondant au mot clé</returns>
        IEnumerable<Artiste> RechercherArtiste(string keyword = "");
    }
}

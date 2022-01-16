using Webzine.Entity;

namespace Webzine.Business.Contracts
{
    public interface IRechercheService
    {
        /// <summary>
        /// Retourne une liste de titres qui correspond au mot clé passé en paramètre
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        IEnumerable<Titre> RechercherTitre(string keyword = "");

        /// <summary>
        /// Retourne une liste d'artiste qui correspond au mot clé passé en paramètre
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        IEnumerable<Artiste> RechercherArtiste(string keyword = "");
    }
}

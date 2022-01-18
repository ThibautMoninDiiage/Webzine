using Webzine.Business.Contracts;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Business
{
    public class RechercheService : IRechercheService
    {
        private readonly IArtisteRepository _artisteRepository;
        private readonly ITitreRepository _titreRepository;

        public RechercheService(IArtisteRepository artisteRepository, ITitreRepository titreRepository)
        {
            _artisteRepository = artisteRepository;
            _titreRepository = titreRepository;
        }

        /// <summary>
        /// Méthode qui permet de rechercher un artiste dans la base de données
        /// </summary>
        /// <param name="keyword">Nom de l'artiste</param>
        /// <returns>La liste d'artiste correspondant au mot clé</returns>
        public IEnumerable<Artiste> RechercherArtiste(string keyword = "")
        {
            return _artisteRepository.FindAll().Where(a => a.Nom.ToLower().Contains(keyword.ToLower()));
        }


        /// <summary>
        /// Méthode qui permet de rechercher un titre dans la base de données
        /// </summary>
        /// <param name="keyword">Nom du titre</param>
        /// <returns>La liste de titre correspondant au mot clé</returns>
        public IEnumerable<Titre> RechercherTitre(string keyword = "")
        {
            return _titreRepository.FindAll().Where(t => t.Libelle.ToLower().Contains(keyword.ToLower()) || t.Artiste.Nom.ToLower().Contains(keyword.ToLower()));

        }
    }
}

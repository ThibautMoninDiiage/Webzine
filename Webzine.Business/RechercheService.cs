using System;
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


        
        public IEnumerable<Artiste> RechercherArtiste(string keyword = "")
        {
            return _artisteRepository.FindAll().Where(a => a.Nom.ToLower().Contains(keyword.ToLower()));
        }

        
        public IEnumerable<Titre> RechercherTitre(string keyword = "")
        {
            return _titreRepository.FindAll().Where(t => t.Libelle.ToLower().Contains(keyword.ToLower()));

        }
    }
}


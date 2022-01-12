using Webzine.Repository.Contracts;
using Webzine.WebApplication.ViewModels;

namespace Webzine.Business.Contracts
{
    public class ServiceSearchable
    {
        private readonly IArtisteRepository _artisteRepository;
        private readonly ITitreRepository _titreRepository;

        public ServiceSearchable(IArtisteRepository artisteRepository, ITitreRepository titreRepository)
        {
            _artisteRepository = artisteRepository;
            _titreRepository = titreRepository;
        }

        public SearchViewModel Searchable(string keyword)
        {
            if (!String.IsNullOrWhiteSpace(keyword) || !String.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
            }
            else
            {
                keyword = "";
            }

            var model = new SearchViewModel
            {
                Keyword = keyword,
                Artistes = _artisteRepository.FindAll().Where(a => a.Nom.ToLower().Contains(keyword)),
                Titres = _titreRepository.FindAll().Where(t => t.Libelle.ToLower().Contains(keyword))
            };

            return model;
        }
    }
}

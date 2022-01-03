using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface ITitreRepository
    {
        // Ajoute un nouveau titre.
        void AddTitre(Titre titre);
        // Supprime un titre.
        void DeleteTitre(Titre titre);
        // Compte le nombre de titres.
        int Count();
        // Retourne le titre demandé à partir de son identifiant.
        Titre Find(int idTitre);
        // Retourne les titres demandés (pour la pagination) triés selon la date de création (du plus récent au plus ancien)
        IEnumerable<Titre> FindTitres(int offset, int limit);
        // Retourne tous les titres.
        IEnumerable<Titre> FindAll();
        // Incrémente le nombre de lectures d'un titre.
        void IncrementNbLectures(Titre titre);
        // Incrémente le nombre de likes d'un titre.
        void IncrementNbLikes(Titre titre);
        // Recherche, de manière insensible à la casse, les titres contenant le mot cherché.
        IEnumerable<Titre> SearchByStyle(string libelle);
        // Met à jour un titre.
        void Update(Titre titre);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Business.Contracts
{
    public interface IPictureService
    {
        /// <summary>
        /// Enregistre une image en local dans un dossier du projet
        /// </summary>
        /// <param name="urlPicture">Url complet de l'image</param>
        void SavePicture(string urlPicture, string filename);
    }
}

using System.Net;
using Webzine.Business.Contracts;

namespace Webzine.Business
{
    public class PictureService : IPictureService
    {
        private readonly string foldername = "titresCover";


        /// <summary>
        /// Cette méthode permet d'enregistrer une photo en local à partir de son url dans wwwroot/xxx/filename
        /// </summary>
        /// <param name="urlPicture">lien de l'image</param>
        /// <param name="filename">nom du fichier à enregister</param>
        /// <returns>Retourne le nom du fichier</returns>
        public string SavePicture(string urlPicture, string filename)
        {
            using (WebClient client = new WebClient())
            {
                Directory.CreateDirectory($"wwwroot/{foldername}");
                client.DownloadFile(new Uri(urlPicture), $"wwwroot/{foldername}/{filename}.jpg");
            }
            return $"/{foldername}/{filename}.jpg";
        }
    }
}

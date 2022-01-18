using System.Net;
using Webzine.Business.Contracts;

namespace Webzine.Business
{
    public class PictureService : IPictureService
    {
        private readonly string foldername = "titresCover";

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

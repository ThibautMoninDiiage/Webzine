using System.Net;
using Webzine.Business.Contracts;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Webzine.Business
{
    public class PictureService : IPictureService
    {
        public string SavePicture(string urlPicture, string filename)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(urlPicture);

                using (MemoryStream mem = new MemoryStream(data))
                {
                    using (var yourImage = Image.FromStream(mem))
                    {
                        Directory.CreateDirectory("wwwroot/TitresCover");
                        yourImage.Save("wwwroot/TitresCover/" + filename + ".jpg", ImageFormat.Jpeg);
                    }
                }
            }
            return $"/TitresCover/{filename}.jpg";
        }
    }
}

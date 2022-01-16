namespace Webzine.Business.Contracts
{
    public interface IPictureService
    {
        /// <summary>
        /// Enregistre une image en local dans un dossier du projet
        /// </summary>
        /// <param name="urlPicture">Url complet de l'image</param>
        string SavePicture(string urlPicture, string filename);
    }
}

namespace Webzine.Business.Contracts
{
    public interface IPictureService
    {
        /// <summary>
        /// Cette méthode permet d'enregistrer une photo en local à partir de son url dans wwwroot/xxx/filename
        /// </summary>
        /// <param name="urlPicture">lien de l'image</param>
        /// <param name="filename">nom du fichier à enregister</param>
        /// <returns>Retourne le nom du fichier</returns>
        string SavePicture(string urlPicture, string filename);
    }
}

namespace Webzine.Business.Contracts
{
    public interface IJsonService
    {
        /// <summary>
        /// Cette méthode écrit dans un fichier JSON à l'emplacement wwwroot/data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename">Nom du fichier</param>
        /// <param name="param">Type de l'objet à convertir</param>
        void WriteJsonFile<T>(string filename, T param);

        /// <summary>
        /// Permet de lire un fichier json à l'emplacement wwwroot/data
        /// </summary>
        /// <typeparam name="T">Classe pour la deserialisation</typeparam>
        /// <param name="filename">Nom du fichier à lire</param>
        /// <returns></returns>
        T ReadJsonFile<T>(string filename);
    }
}

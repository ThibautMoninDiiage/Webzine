using Newtonsoft.Json;
using Webzine.Business.Contracts;

namespace Webzine.Business
{
    public class JsonService : IJsonService
    {
        /// <summary>
        /// Cette méthode écrit dans un fichier JSON à l'emplacement wwwroot/data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename">Nom du fichier</param>
        /// <param name="param">Type de l'objet à convertir</param>
        public void WriteJsonFile<T>(string filename, T param)
        {
            Directory.CreateDirectory("wwwroot/data");
            File.WriteAllText($"wwwroot/data/{filename}", JsonConvert.SerializeObject(param));
        }

        /// <summary>
        /// Permet de lire un fichier json à l'emplacement wwwroot/data
        /// </summary>
        /// <typeparam name="T">Classe pour la deserialisation</typeparam>
        /// <param name="filename">Nom du fichier à lire</param>
        /// <returns></returns>
        public T ReadJsonFile<T>(string filename)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText($"wwwroot/data/{filename}"));
        }
    }
}

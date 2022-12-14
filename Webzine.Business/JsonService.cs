using Newtonsoft.Json;
using Webzine.Business.Contracts;

namespace Webzine.Business
{
    public class JsonService : IJsonService
    {
        public void WriteJsonFile<T>(string filename, T param)
        {
            Directory.CreateDirectory("wwwroot/data");
            File.WriteAllText($"wwwroot/data/{filename}", JsonConvert.SerializeObject(param));
        }

        public T ReadJsonFile<T>(string filename)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText($"wwwroot/data/{filename}"));
        }
    }
}

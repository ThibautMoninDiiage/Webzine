using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webzine.Business.Contracts;
using Newtonsoft.Json;
using Webzine.Entity;

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

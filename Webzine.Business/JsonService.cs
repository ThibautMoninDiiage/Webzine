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
        public void WriteJsonFile<T>(string path, T param)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(param));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webzine.Business.Contracts;
using Newtonsoft.Json;

namespace Webzine.Business
{
    public class JsonService : IJsonService
    {
        public void WriteJsonFile()
        {
            var data = new Test()
            {
                Id = 1,
                Name = "Ok"
            };

            File.WriteAllText("", JsonConvert.SerializeObject(data));
        }
    }

    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Webzine.Business.Contracts
{
    public interface IJsonService
    {
        void WriteJsonFile<T>(string path, T param);
    }
}

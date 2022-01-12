using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.DTO
{
    public class DeezerRequest
    {
        public List<Titre> Data { get; set; }
        public string Tracklist { get; set; }
    }
}

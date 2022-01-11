using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.DTO
{
    public class TrackDTO
    {
        [Key]
        [JsonProperty("id")]
        public int IdTrack { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Web.Services.Services.DTOs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SpaceStationPosition
    {
        [JsonProperty("latitude")]
        public double LatitudeJson { get; set; }

        [JsonProperty("longitude")]
        public double LongitudeJson { get; set; }

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Web.Services.Services.DTOs
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SpaceStationData
    {
        [JsonProperty("iss_position")]
        public SpaceStationPosition spaceStationPosition { get; set; }

        [JsonProperty("timestamp")]
        public double TimestampFirstRequest { get; set; }

        [JsonProperty("message")]
        public string MessageFirstRequest { get; set; }

        public double LatitudeFirstRequest { get; set; }

        public double LongitudeFirstRequest { get; set; }

        public double LatitudeSecondRequest { get; set; }

        public double LongitudeSecondRequest { get; set; }

        public double TimestampSecondRequest { get; set; }

        public string MessageSecondRequest { get; set; }
    }
}

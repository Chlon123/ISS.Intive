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
        public double TimestampJsonRequest { get; set; }

        [JsonProperty("message")]
        public string MessageJsonRequest { get; set; }

        public double LatitudeJsonRequest { get; set; }

        public double LongitudeJsonRequest { get; set; }

        public double LatitudeSecondRequired { get; set; }

        public double LongitudeSecondRequired { get; set; }

        public double TimestampSecondRequired { get; set; }

        public string MessageSecondRequired { get; set; }

        public double CoordinateX1 { get; set; }

        public double CoordinateY1 { get; set; }

        public double CoordinateZ1 { get; set; }

        public double CoordinateX2 { get; set; }

        public double CoordinateY2 { get; set; }

        public double CoordinateZ2 { get; set; }

    }
}

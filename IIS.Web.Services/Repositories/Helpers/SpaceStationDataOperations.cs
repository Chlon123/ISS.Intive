using IIS.Web.Services.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Web.Services.Repositories.Helpers
{
    public static class SpaceStationDataOperations
    {
        public static SpaceStationData CombineSpaceStation(SpaceStationData firstRequestObject, SpaceStationData secondRequestObject)
        {
            SpaceStationData combinedSpaceStationDatas = new SpaceStationData()
            {
                LatitudeFirstRequest = firstRequestObject.spaceStationPosition.LatitudeJson,
                LatitudeSecondRequest = secondRequestObject.spaceStationPosition.LatitudeJson,
                LongitudeFirstRequest = firstRequestObject.spaceStationPosition.LongitudeJson,
                LongitudeSecondRequest = secondRequestObject.spaceStationPosition.LongitudeJson,
                TimestampFirstRequest = firstRequestObject.TimestampFirstRequest,
                TimestampSecondRequest = secondRequestObject.TimestampFirstRequest
            };

            return combinedSpaceStationDatas;
        }



    }
}

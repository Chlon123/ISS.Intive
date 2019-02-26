using IIS.Web.Services.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IIS.Web.API.Helpers
{
    public static class SpaceStationHandler
    {

        public async static Task<SpaceStationData> GetNecessaryData(string url)
        {
            SpaceStationData spaceStationAsDeserializedJsonOne =
                await GetDeserializedJsonData<SpaceStationData>.DeserializedJsonData(url);

            SpaceStationData spaceStationAsDeserializedJsonTwo =
                 await GetDeserializedJsonData<SpaceStationData>.DeserializedJsonData(url);


            if (!spaceStationAsDeserializedJsonOne.MessageJsonRequest.Equals(ConnectionStatus.success.ToString())
                || !spaceStationAsDeserializedJsonTwo.MessageJsonRequest.Equals(ConnectionStatus.success.ToString()))
            {
                return null;
            }

            SpaceStationData combinedSpaceStationDatas = new SpaceStationData()
            {
                LatitudeJsonRequest = spaceStationAsDeserializedJsonOne.spaceStationPosition.LatitudeJson,
                LatitudeSecondRequired = spaceStationAsDeserializedJsonTwo.spaceStationPosition.LatitudeJson,
                LongitudeJsonRequest = spaceStationAsDeserializedJsonOne.spaceStationPosition.LongitudeJson,
                LongitudeSecondRequired = spaceStationAsDeserializedJsonTwo.spaceStationPosition.LongitudeJson,
                TimestampJsonRequest = spaceStationAsDeserializedJsonOne.TimestampJsonRequest,
                TimestampSecondRequired = spaceStationAsDeserializedJsonTwo.TimestampJsonRequest
            };

            return combinedSpaceStationDatas;
        }
    }
}
using IIS.Web.Services.DbContexts;
using IIS.Web.Services.Services.DTOs;
using IIS.Web.Services.UnitOfWork;
using IIS.Web.Services.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace IIS.Web.API.Helpers
{
    public class SpaceStationHandler
    {
        private static HttpClient _client;
        private readonly IISDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public SpaceStationHandler()
        {
            _client = new HttpClient();
            _dbContext = new IISDbContext();
            _unitOfWork = new UnitOfWork(_dbContext);
        }

        public async Task<SpaceStationData> GetNecessaryData(string url)
        {

            SpaceStationData firstReqDeserializedObject = await DeserializeSpaceStationObject(_client, url);

            await Task.Delay(1000);

            SpaceStationData secondReqDeserializedObject = await DeserializeSpaceStationObject(_client, url);

            SpaceStationData combinedSpaceStation = _unitOfWork
                                                    .CalculationDataRepository
                                                    .GetCombinedSpaceStationData(firstReqDeserializedObject, secondReqDeserializedObject);
                
            return combinedSpaceStation;
        }

        private async Task<SpaceStationData> DeserializeSpaceStationObject(HttpClient client, string url)
        {
            SpaceStationData deserializedObject = await new GetDeserializedJsonData<SpaceStationData>(_client, url).DeserializedJsonData();

            return deserializedObject;
        }
    }
}
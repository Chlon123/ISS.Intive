using IIS.Web.Models;
using IIS.Web.Services.DbContexts;
using IIS.Web.Services.Repositories.Enums;
using IIS.Web.Services.Repositories.Helpers;
using IIS.Web.Services.Repositories.Interfaces;
using IIS.Web.Services.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Web.Services.Repositories
{
    public class CalculationDataRepository : ICalculationDataRepository
    {
        private readonly IISDbContext _context;
        
        public CalculationDataRepository(IISDbContext context)
        {
            _context = context;
        }

        public SpaceStationData GetCombinedSpaceStationData(SpaceStationData firstRequestObject, SpaceStationData secondRequestObject)
        {
            if (!firstRequestObject.MessageFirstRequest.Equals(ConnectionStatus.success.ToString())
                 || !secondRequestObject.MessageFirstRequest.Equals(ConnectionStatus.success.ToString()))
            {
                return null;
            }

            SpaceStationData combinedSpaceStation = SpaceStationDataOperations.CombineSpaceStation(firstRequestObject, secondRequestObject);

            return combinedSpaceStation;
        }

        public CalculatedSpaceStation GetSpeedAndTotalDistance(SpaceStationData spaceStation)
        {
            double eRadius = _context.CalculationDatas.Select(d => d.EarthRadius).First();

            CalculatedSpaceStation result = CalculationFormulas.CalculateVelocityAndDistance(eRadius, spaceStation);

            return result;
        }
    }
}

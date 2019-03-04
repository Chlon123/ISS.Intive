using IIS.Web.Models;
using IIS.Web.Services.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Web.Services.Repositories.Interfaces
{
    public interface ICalculationDataRepository
    {
        CalculatedSpaceStation GetSpeedAndTotalDistance(SpaceStationData spaceStation);

        SpaceStationData GetCombinedSpaceStationData(SpaceStationData firstRequestObject, SpaceStationData secondRequestObject);
    }
}

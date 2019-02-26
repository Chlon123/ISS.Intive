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
        IDictionary<string, double> GetSpeedandTotalDistance(SpaceStationData spaceStation);
    }
}

using IIS.Web.Models;
using IIS.Web.Services.DbContexts;
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

        public double GetSpeed(SpaceStationData spaceStation)
        {
            double eRadius = _context.CalculationDatas.Select(d => d.EarthRadius).First();

            double speed = CalculationFormulas.CalculateVelocity(eRadius, spaceStation);

            return speed;
        }


        public double GetTotalDistance(SpaceStationData spaceStation)
        {
            double eRadius = _context.CalculationDatas.Select(d => d.EarthRadius).First();

            double totalDist = CalculationFormulas.GetTotalDistance(spaceStation, eRadius);

            return totalDist;
        }

        public IDictionary<string, double> GetSpeedandTotalDistance(SpaceStationData spaceStation)
        {

            double totalDistance = GetTotalDistance(spaceStation);
            double spaceStationVelocity = GetSpeed(spaceStation);

            IDictionary<string, double> results = new Dictionary<string, double>
            {
                {"Distance", totalDistance },
                {"Velocity", spaceStationVelocity }
            };

            return results;
        }
    }
}

using IIS.Web.Models;
using IIS.Web.Services.DbContexts;
using IIS.Web.Services.Repositories.Helpers;
using IIS.Web.Services.Repositories.Interfaces;
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

        public double CalculateDistance(IDictionary<string, double> datas)
        {
            double lat1 = datas["latitude1"];
            double lon1 = datas["longitude1"];
            double lat2 = datas["latitude2"];
            double lon2 = datas["longitude2"];
            double eRadius = _context.CalculationDatas.Select(d => d.EarthRadius).First();

            double dist = CalculationFormulas.CaculateDistanceInMeters(lat1, lat2, lon1, lon2, eRadius);

            return dist;
        }
    }
}

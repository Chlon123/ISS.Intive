using IIS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Web.Services.Repositories.Interfaces
{
    public interface ICalculationDataRepository
    {
        double CalculateDistance(IDictionary<string, double> datas);

    }
}

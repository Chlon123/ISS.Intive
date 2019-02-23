using IIS.Web.Services.DbContexts;
using IIS.Web.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Web.Services.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        ICalculationDataRepository CalculationDataRepository { get; set; }

        void Complete();


    }
}

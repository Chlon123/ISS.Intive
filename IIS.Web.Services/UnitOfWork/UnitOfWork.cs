using IIS.Web.Services.DbContexts;
using IIS.Web.Services.Repositories;
using IIS.Web.Services.Repositories.Interfaces;
using IIS.Web.Services.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Web.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IISDbContext _context;
        public ICalculationDataRepository CalculationDataRepository { get ; set; }

        public UnitOfWork(IISDbContext context)
        {
            _context = context;
            CalculationDataRepository = new CalculationDataRepository(_context);
        }


        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}

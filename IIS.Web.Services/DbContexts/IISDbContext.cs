using IIS.Web.Models;
using IIS.Web.Services.DbContexts.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Web.Services.DbContexts
{
    public class IISDbContext : DbContext
    {
        public IISDbContext()
            : base(DbContextConnectionStrings.IISConnection.ToString())
        {

        }

        public DbSet<CalculationData> CalculationDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

    }
}

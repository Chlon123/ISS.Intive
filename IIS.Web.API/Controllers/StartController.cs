using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IIS.Web.Services.UnitOfWork;
using IIS.Web.Services.DbContexts;
using IIS.Web.Services.UnitOfWork.Interfaces;

namespace IIS.Web.API.Controllers
{
    public class StartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IISDbContext _dbContext;

        public StartController()
        {
            _dbContext = new IISDbContext();
            _unitOfWork = new UnitOfWork(_dbContext);
        }



        // GET: Start
        public ActionResult Start()
        {
            return View();
        }
    }
}
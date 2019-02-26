using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Results;
using IIS.Web.Services.UnitOfWork;
using IIS.Web.Services.DbContexts;
using IIS.Web.Services.UnitOfWork.Interfaces;
using System.Web.Http;
using IIS.Web.Services.Services.DTOs;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IIS.Web.API.Helpers;

namespace IIS.Web.API.Controllers
{
    public class StartController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IISDbContext _dbContext;

        public StartController()
        {
            _dbContext = new IISDbContext();
            _unitOfWork = new UnitOfWork(_dbContext);
        }


        //GET: Start
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> SpaceTravel()
        {
            try
            {
                SpaceStationData SpaceStationDatas = await SpaceStationHandler.GetNecessaryData("http://api.open-notify.org/iss-now.json");

                if (SpaceStationDatas == null)
                {
                    return BadRequest();
                }

                IDictionary<string, double> finalData = _unitOfWork.CalculationDataRepository.GetSpeedandTotalDistance(SpaceStationDatas);

                return Ok(finalData);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }



    }


}
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
using System.Web.Http.Cors;

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
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> SpaceTravel()
        {
            try
            {
                SpaceStationData SpaceStationDatas = await new SpaceStationHandler().GetNecessaryData("http://api.open-notify.org/iss-now.json");

                if (SpaceStationDatas == null)
                {
                    return BadRequest("We are sorry, the ISS service from which you are trying get response is not avaiable at the moment!");
                }

                CalculatedSpaceStation finalData = _unitOfWork.CalculationDataRepository.GetSpeedAndTotalDistance(SpaceStationDatas);


                return Ok(finalData);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex)
            }

        }



    }


}
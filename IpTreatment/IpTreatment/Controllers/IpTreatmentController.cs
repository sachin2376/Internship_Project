using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IpTreatment.Entities;
using IpTreatment.Repository;
using IpTreatment.Repository.Interfaces;
//using IpTreatment.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IpTreatment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class IpTreatmentController : Controller
    {
        private readonly ITreatmentPlans _tPrepo;
        private readonly IPatients _prepo;
        private readonly IOfferings _orepo;
        private readonly ILogger<IpTreatmentController> log;
        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(IpTreatmentController));

        public IpTreatmentController(ITreatmentPlans _TPrepo, IPatients _Prepo, IOfferings _Orepo, ILogger<IpTreatmentController> log)
        {
            _tPrepo = _TPrepo;
            _prepo = _Prepo;
            _orepo = _Orepo;
            this.log = log;
        }


        [HttpGet]
        public IActionResult Get([FromBody] Patient patient)
        {
            logger.Info(" Creating a Treatment Plan..... ! ");
            TreatmentPlan treatmentPlan;
            if (patient == null)
            {
                logger.Error(" Patient :: null || Got null values(GET method!!)");
                return BadRequest(" Null !");
            }
            try
            {
                treatmentPlan = _tPrepo.CreateTreatmentPlan(patient);
            }catch(NullReferenceException e)
            {
                logger.Error($" Exception occurred : {e.Message}");
                return BadRequest(" Null Exception");
            }
            catch(InvalidOperationException e)
            {
                logger.Error(e.Message);
                return BadRequest(e.Message);
            }
            
            return Ok(treatmentPlan);
        }




        [HttpGet("getpatients")]
        public IActionResult GetPatients()
        {
            logger.Info(" Getting patients list");
            if(_prepo.GetPatients()!=null)
                return Ok(_prepo.GetPatients());
            logger.Error(" Exception : while getting patients");
            return BadRequest(" Failed to return patients List");
        }


        [HttpGet("gettreatmentplans")]
        public IActionResult GetTreatMentPlans()
        {
            logger.Info(" Getting Treatment plans");
            if (_tPrepo.GetTreatmentPlans() != null)
                return Ok(_tPrepo.GetTreatmentPlans());
            logger.Error(" Exception : while getting treatment plans");
            return BadRequest(" Failed to return TreatmentPlans List");
        }



        [HttpGet("getPackages")]
        public ActionResult<Package> GetPackages()
        {
            List<Package> a;
            try
            {
                 a= _orepo.GetPackages();

            }
            catch (Exception e)
            {
                logger.Info(e.Message);
                Console.WriteLine(e.Message);
                return null;
            }
            return Ok(a);
        }
    }
}
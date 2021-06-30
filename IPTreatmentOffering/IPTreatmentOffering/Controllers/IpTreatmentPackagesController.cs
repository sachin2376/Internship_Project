using System.Collections.Generic;
using IPTreatmentOffering.Entities;
using IPTreatmentOffering.Repository;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IPTreatmentOffering.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class IpTreatmentPackagesController : Controller
    {
        
        public IpTreatmentPackagesController(IIpTreatmentPackages _ITPrepo,IPackage _Prepo,ISpecialist _Srepo)
        {
            this._ITPrepo = _ITPrepo;
            this._Prepo = _Prepo;
            this._Srepo = _Srepo;
            
        }

        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(IpTreatmentPackagesController));
        private readonly IIpTreatmentPackages _ITPrepo;
        private readonly IPackage _Prepo;
        private readonly ISpecialist _Srepo;
        

        [HttpGet("get/iptreatmentpackages")]
        public IActionResult Get()
        {
            logger.Info("(GET) IpTreatmentPackages - api");
            IEnumerable<IpTreatmentPackage> TreatmentPackages = _ITPrepo.GetAllIpTreatmentPackages();
            if (TreatmentPackages==null)
            {
                logger.Error(" Treatment Packages -- null || Failed to get list");
                return BadRequest("Failed to get list");
            }
            return Ok(TreatmentPackages);
        }

        
        [HttpGet("{packagename}")]
        public IActionResult Get(string packagename)
        {
            IpTreatmentPackage ipTreatmentPackage = _ITPrepo.GetIpTreatmentPackage(packagename);
            if(ipTreatmentPackage == null)
            {
                logger.Error(" iptreatmentPackage : null || Failed to get package!");
                return BadRequest(" Package Not Found");
            }
            return Ok(ipTreatmentPackage);
        }

        
        [HttpGet("get/packages")]
        public IActionResult GetPackages()
        {
            logger.Info(" Getting All Packages");
            return Ok(_Prepo.GetAllPackages());
        }

        [HttpGet("get/specialists")]
        public IActionResult GetSpecialists()
        {
            logger.Info(" Getting All Specialists");
            return Ok(_Srepo.GetAllSpecialists()) ;
        }

    }
}

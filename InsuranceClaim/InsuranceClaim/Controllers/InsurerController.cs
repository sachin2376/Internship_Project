using System;
using InsuranceClaim.Entities;
using InsuranceClaim.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InsuranceClaim.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class InsurerController : Controller
    {
        private readonly IInsurer iIrepo;
        private readonly IInsuranceClaims iCrepo;
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(InsurerController));

        public InsurerController(IInsurer _IIrepo, IInsuranceClaims _ICrepo)
        {
            iIrepo = _IIrepo;
            iCrepo = _ICrepo;
        }

        [HttpGet("getinsurerdetails")]
        public IActionResult Get()
        {
            _logger.Info("Getting Insurer Details");
            return Ok(iIrepo.GetAllInsurer());
        }

        
        [HttpGet("{packagename}")]
        public IActionResult Get(string packagename)
        {
            _logger.Info(" Getting Insurance provide by package name");
            Insurer insurer = iIrepo.GetInsurerByPackage(packagename);
            if (insurer == null)
            {
                _logger.Error($"Package {packagename} Not found in database !.. ");
                return BadRequest($"Insurer with {packagename} doesnot exists in database ");
            }
            else
                _logger.Info($" Insurer {insurer.InsurerName} returned !");
            return Ok(insurer);
        }


        [HttpGet("getinsuranceclaims")]
        public IActionResult InsuranceClaims()
        {
            _logger.Info(" Getting insurance claims list");
            return Ok(iCrepo.GetAllInitiateClaims());
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] InitiateClaim claim)
        {
            _logger.Info(" Executing Post method ....!");
            var amount = 0.0;
            try
            {
                amount = iCrepo.CreateInsuranceClaim(claim);
            }
            catch(NullReferenceException e)
            {
                _logger.Error(" Exception occurred while creating Initiate claims object!!");
                return BadRequest(e.Message);
            }
            catch(InvalidOperationException e)
            {
                _logger.Error(" Exception occurred while creating Initiate claims object!!");
                return BadRequest(e.Message);
            }
            return Ok(amount);
        }
    }
}

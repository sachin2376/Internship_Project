using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IpTreatmentManagementPortal.Context;
using IpTreatmentManagementPortal.Entities;
using IpTreatmentManagementPortal.ErrorClass;
using IpTreatmentManagementPortal.Repository;
using IpTreatmentManagementPortal.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace IpTreatmentManagementPortal.Controllers
{

    public class AdminController : Controller
    {
        private readonly OfferingsRepo _Orepo;
        private readonly PatientRepo _Prepo;
        private readonly InsurerRepo _Irepo;
        private readonly InitiateClaimsRepo _ICrepo;
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;
        private readonly PatientDBContext context;
        private readonly IUserLog iLog;

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AdminController));

        public AdminController(OfferingsRepo _Orepo, PatientRepo _Prepo, InsurerRepo _Irepo, InitiateClaimsRepo _ICrepo, HttpClient httpClient, IConfiguration _Config, PatientDBContext context, IUserLog _ILog)
        {
            this._Orepo = _Orepo;
            this._Prepo = _Prepo;
            this._Irepo = _Irepo;
            this._ICrepo = _ICrepo;
            this.httpClient = httpClient;
            config = _Config;
            this.context = context;
            iLog = _ILog;
        }



        public IActionResult Index()
        {
            logger.Info("Home page...");
            
            return View();
        }


        [HttpGet]
        public IActionResult GetTreatmentOfferings()
        {
            
            logger.Info(" Executing GetIpTreatmentOffering.......");
            try
            {
                ViewBag.Packages = _Orepo.GetIpPackages();
                return View(_Orepo.GetIpTreatmentPackages());

            }catch(Exception e)
            {
                logger.Error($"Exception occurred in GetTreatmentPackages : {e.Message} ");

                Errorclass errorclass = new("Admin", "GetTreatmentOfferings", e.Message);
                return RedirectToAction("DisplayError", "Error", errorclass);
            }
        }


        [HttpGet]
        public IActionResult RegisterPatient()
        {
            ViewBag.context = context;
            logger.Info(" Executing RegisterPatient Action .....");
            List<Package> packages;
            try
            {
                packages = _Orepo.GetIpPackages();
            }
            catch (Exception e)
            {
                logger.Error($"Exception while in RegisterPatient ");
                Errorclass errorclass = new("Admin", "RegisterPatient",e.Message);
                return RedirectToAction("DisplayError", "Error", errorclass);
            }
            ViewBag.Packages = packages;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> FormulateTimeTable(Patient patient)
        {
            logger.Info(" Executing FormulatePlan ........");
            TreatmentPlan treatmentPlan;
            try
            {
                treatmentPlan = await _Prepo.FormulateTimeTable(patient);
            }
            catch(Exception e)
            {
                logger.Error($"Exception occurred : Did not get Treatment plan object >> {e.Message}");
                Errorclass errorclass = new("Admin", "FormulateTimeTable", e.Message);
                return RedirectToAction("DisplayError", "Error", errorclass);
            }



            List<Patient> patients;
            try
            {
                patients =await _Prepo.GetPatients();
            }
            catch (Exception e)
            {
                logger.Error($"Exception occurred : {e.Message} ");
                Errorclass errorclass = new("Admin", "FormulateTimeTable", e.Message);
                return RedirectToAction("DisplayError", "Error",errorclass );
            }
            ViewBag.Patients = patients;
            return View(treatmentPlan);
        }


        [HttpGet]
        public async Task<IActionResult> Patients()
        {
            logger.Info(" Executing Patients ..........");
            List<Patient> patients;
            try
            {
                patients = await _Prepo.GetPatients();
            }
            catch (Exception e)
            {
                logger.Error($"Exception occurred : {e.Message} ");
                Errorclass errorclass = new("Admin", "(GET) Patients",e.Message);
                return RedirectToAction("DisplayError", "Error",errorclass );
            }
            return View(patients);
        }


        [HttpGet]
        public async Task<IActionResult> AddInsurer(string id)
        {
            logger.Info(" Executing AddInsurer ...... ");
            List<Patient> Patients = await _Prepo.GetPatients();

            
            Patient patient = Patients.Where(p => p.PatientId == id).FirstOrDefault();
            if (patient == null)
                logger.Error("Patient not found :: {AddInsurer Action}");
            ViewBag.Patient = patient;


            try
            {
                _Irepo.GetInsurers().Wait();
                ViewBag.Insurers = _Irepo.Insurers;
            }
            catch (Exception e)
            {
                logger.Error($"Exception occurred : {e.Message} ");
                Errorclass errorclass = new("Admin", "AddInsurer",e.Message);
                return RedirectToAction("DisplayError", "Error", errorclass);
            }

            logger.Info(" New insurance claim initiated .....!");
            InitiateClaim claim = _ICrepo.CreateClaim(patient);
            return View(claim);
        }


        [HttpPost]
        public async Task<IActionResult> AddInsurer(InitiateClaim claim)
        {
            logger.Info("..Executing AddInsurer(POST) method ");
            double result;
            try
            {
                result =await _ICrepo.AddClaim(claim, httpClient);
            }
            catch(Exception e)
            {
                logger.Error($"Exception occurred : {e.Message}");
                Errorclass errorclass = new("Admin", "AddInsurer",e.Message);
                return RedirectToAction("DisplayError", "Error",errorclass);
            }
            return View("Result", result);
        }

    
        public async Task<ActionResult<Insurer>> GetInsurer()
        {
            _ = await _Irepo.GetInsurers();
            List<Insurer> list = _Irepo.Insurers;
            if (list != null)
            {
                return View(_Irepo.Insurers);
            }
            Errorclass errorclass = new("Admin", "GetInsurer", "Insurer list null!!");
            return RedirectToAction("DisplayError", "Error", errorclass);

        }

        public async Task<ActionResult<InitiateClaim>> GetRegisteredClaims()
        {
            try
            {
                _ = await _ICrepo.GetInitiateClaims();
            }
            catch(Exception e)
            {
                Errorclass errorclass = new("Admin", "GetRegisteredClaims",e.Message);
                return RedirectToAction("DisplayError", "Error", errorclass );
            }
            return View(_ICrepo.InitiateClaims);
            
        }

        public IActionResult kk() => View("Login");


        [HttpPost]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            logger.Info(" Executing Login ......");
            try
            {
                bool result = await iLog.Login(userModel);
            }
            catch (Exception)
            {
                ViewBag.Controller = "Admin";
                ViewBag.Action = "Login";
                ViewBag.ErrorMessage = "Invalid username or password/ Credentials doesn't match";
                logger.Error($"Exception occurred : {ViewBag.ErrorMessage} ");
                return View("Login");
            }
            return RedirectToAction("Index", "Admin");
        }


        public IActionResult LogoutUser()
        {
            if (!iLog.Logout())
            {
                logger.Error("Logout Failed");
                Errorclass errorclass = new("Admin", "LogoutUser", "Logout failed");
                return RedirectToAction("DisplayError", "Error", errorclass);
            }
            return RedirectToAction("kk");
        }
    }
}

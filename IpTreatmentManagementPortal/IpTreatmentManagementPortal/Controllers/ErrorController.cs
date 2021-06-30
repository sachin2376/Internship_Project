using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IpTreatmentManagementPortal.ErrorClass;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IpTreatmentManagementPortal.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult DisplayError(Errorclass errorclass)
        {
            //ViewBag.Controller = errorclass.controllername;
            //ViewBag.Action = errorclass.ActionName;
            //ViewBag.ErrorMessage = errorclass.ErrorMessage;
            return View(errorclass);
        }

    }
}

using System;
using IpTreatment.Controllers;
using IpTreatment.Entities;
using IpTreatment.Repository;
using IpTreatment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace IpTreatmentTest
{
    [TestFixture]
    public class IpTreatmentTests
    {
        private Mock<ITreatmentPlans> _mockTP;
        private Mock<IPatients> _mockP;
        private Mock<IOfferings> _mockOrepo;
        private Mock<ILogger<IpTreatmentController>> _mockLog;
        private IpTreatmentController IPTcontroller;

        [SetUp]
        public void Setup()
        {
            _mockTP = new Mock<ITreatmentPlans>();
            _mockP = new Mock<IPatients>();
            _mockOrepo = new Mock<IOfferings>();
            _mockLog = new Mock<ILogger<IpTreatmentController>>(); 
        }

        //[Test]
        //public void GettingTreatmentPlan_ForNew_Valid_PatientRegistration()
        //{
        //    IPTcontroller = new IpTreatmentController(_mockTP.Object,_mockP.Object,_mockOrepo.Object,_mockLog.Object);
        //    Patient patient = new()
        //    {
        //        PatientId = "P103",
        //        PatientName = "Naresh dabhode",
        //        Ailment = "Neurology",
        //        PatientAge = 29,
        //        TreatmentStatus = "In-Progress",
        //        TreatmentpackageName = "NPT_Package2",
        //        TreatmentCommenceDate = Convert.ToDateTime("1990-01-01")
        //    };


        //    _ = _mockTP.Setup(p => p.CreateTreatmentPlan(patient));

        //    var result = IPTcontroller.Get(patient);
        //    Assert.That(result, Is.InstanceOf<OkObjectResult>());
        //}


    }
}
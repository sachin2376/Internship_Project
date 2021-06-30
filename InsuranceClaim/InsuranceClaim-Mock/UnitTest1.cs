using InsuranceClaim.Controllers;
using InsuranceClaim.Entities;
using InsuranceClaim.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace InsuranceClaim_Mock
{
    public class InsuranceClaimTests
    {
        private Mock<IInsuranceClaims> _mockIC;
        private Mock<IInsurer> _mockI;
        private InsurerController insurerController;

        [SetUp]
        public void Setup()
        {
            _mockIC = new Mock<IInsuranceClaims>();
            _mockI = new Mock<IInsurer>();
            insurerController = new InsurerController(_mockI.Object,_mockIC.Object);
        }

        [Test]
        public void GetInsurerByPackagename_WhenExists(string PackageName)
        {
            _mockI.Setup(p=>p.GetInsurerByPackage(PackageName)).Returns(new Insurer());
            IActionResult result = insurerController.Get(PackageName);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
    }
}
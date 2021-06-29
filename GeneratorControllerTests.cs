using NUnit.Framework;
using System;
using System.Web.Mvc;
using THGenerationFinal.Controllers;

namespace THGenerationFinal.Tests
{
    [TestFixture]
    public class GeneratorControllerTests
    {

        private GeneratorController _controller;
        [SetUp]
        public void SetUp()
        {
            _controller = new GeneratorController();
        }

        [Test]
        public void GenerateHistory_WhenCalled_ReturnsView()
        {

            var result = _controller.VerifyPin() as ViewResult;

            Assert.That(result, Is.Not.Null);
            //Assert.AreEqual("Generate History", result.ViewBag.Title);
        }
    }
}

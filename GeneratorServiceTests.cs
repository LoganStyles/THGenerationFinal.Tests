using Moq;
using NUnit.Framework;
using THGenerationFinal.Core.Repositories;
using THGenerationFinal.Core.Services;
using THGenerationFinal.Models.ViewModels;
using THGenerationFinal.Services;

namespace THGenerationFinalTests
{

    [TestFixture]
    public class GeneratorServiceTests
    {

        private IVerificationService _verificationService;
        private Mock<IHistoryRepository> _historyRepository;
        private PinExist _pinStatusModel;
        private const string _pinPrefix = "PEN";


        [SetUp]
        public void Setup()
        {
            _historyRepository = new Mock<IHistoryRepository>();
            _verificationService = new PinVerificationService(_historyRepository.Object);

            _pinStatusModel = new PinExist
            {
                Surname = "James",
                FirstName = "JamesF",
                MiddleName = It.IsAny<string>()
            };
        }


        [TestCase("PEN123456789012", true, "PEN123456789012")]
        [TestCase("123456789012", true, "PEN123456789012")]
        [TestCase("23456789012", false, "PEN23456789012")]
        [TestCase("", false, "")]
        [TestCase(" ", false, "")]
        [TestCase("pen", false, "PENpen")]
        [TestCase("penPEN123456789012", false, "PENPEN123456789012")]
        public void ValidateAndFormatPin_WhenCalled_ReturnsPinInCorrectFormat(string pin, bool expectedStatus, string expectedPin)
        {
            _pinStatusModel.Pin = FormatPin(pin);
            _historyRepository.Setup(repo => repo.GetClientByPin(FormatPin(pin)))
                .Returns(() => _pinStatusModel);
            _historyRepository.Setup(repo => repo.GetECRSClientByPin(FormatPin(pin)))
                .Returns(_pinStatusModel);

            var result = _verificationService.VerifyPin(pin);

            Assert.That(result.Status, Is.EqualTo(expectedStatus));
            Assert.That(result.Pin, Is.EqualTo(expectedPin));
        }

        private string FormatPin(string pin)
        {
            if (!pin.StartsWith(_pinPrefix))
                pin = _pinPrefix + pin;
            return pin;
        }
    }
}

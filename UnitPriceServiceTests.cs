using Moq;
using NUnit.Framework;
using THGenerationFinal.Core.Repositories;
using THGenerationFinal.Core.Services;
using THGenerationFinal.Services;

namespace THGenerationFinalTests
{
    [TestFixture]
    public class UnitPriceServiceTests
    {

        private IUnitPriceService _unitPriceService;
        private Mock<IHistoryRepository> _historyRepository;

        [SetUp]
        public void Setup()
        {
            _historyRepository = new Mock<IHistoryRepository>();
            _unitPriceService = new UnitPriceService(_historyRepository.Object);

        }

        //test that loop breaks when price row list is 5
        //test that loop continues when price row list is <5
        //test that loop continues when price row lilst is >5
        //if price list is null loop continues
        //unitprice date reduces by 1 when loop count is not 5

    }
}

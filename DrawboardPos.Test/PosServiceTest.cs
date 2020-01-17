using DrawboardPos.Interfaces;
using DrawboardPos.Services;
using DrawboardPos.Types;
using Moq;
using System;
using Xunit;

namespace DrawboardPos.Test
{
    /// <summary>
    /// Implements tests for pos service.
    /// </summary>
    public class PosServiceTest
    {
        private Mock<IPromoProcessor<Apple>> _applePromoProcessor;
        private Mock<IPromoProcessor<Biscuit>> _biscuitPromoProcessor;
        private Mock<IPromoProcessor<Cheese>> _cheesePromoProcessor;
        private Mock<IPromoProcessor<DairyMilk>> _dairyMilkPromoProcessor;
        private readonly ProductPortfolio<Tuple<Apple, Biscuit, Cheese, DairyMilk>> _portfolio;

        /// <summary>
        /// Constructor for pos service test.
        /// </summary>
        public PosServiceTest()
        {
            _applePromoProcessor = new Mock<IPromoProcessor<Apple>>();
            _biscuitPromoProcessor = new Mock<IPromoProcessor<Biscuit>>();
            _cheesePromoProcessor = new Mock<IPromoProcessor<Cheese>>();
            _dairyMilkPromoProcessor = new Mock<IPromoProcessor<DairyMilk>>();
            var productSet = new Tuple<Apple, Biscuit, Cheese, DairyMilk>(
                PosServiceTestHelper.AppleProduct, PosServiceTestHelper.BiscuitProduct,
                PosServiceTestHelper.CheeseProduct, PosServiceTestHelper.DairyMilkProduct);
            _portfolio = new ProductPortfolio<Tuple<Apple, Biscuit, Cheese, DairyMilk>>();
            _portfolio.Grocery = productSet;
        }

        /// <summary>
        /// Test to verify the sucess scenarios.
        /// </summary>
        [Fact]
        public void Process_WhenValidProductsListEntered()
        {
            double applePrice = 1.25;
            double biscuitPrice = 4.25;
            double cheesePrice = 1.00;
            double dairyMilkPrice = 0.75;

            _applePromoProcessor.Setup(p => p.Apply(3, applePrice)).Returns(3.00);
            _applePromoProcessor.Setup(p => p.Apply(1, applePrice)).Returns(1.25);

            _biscuitPromoProcessor.Setup(p => p.Apply(2, biscuitPrice)).Returns(8.50);
            _biscuitPromoProcessor.Setup(p => p.Apply(1, biscuitPrice)).Returns(4.25);

            _cheesePromoProcessor.Setup(p => p.Apply(1, cheesePrice)).Returns(1.00);
            _cheesePromoProcessor.Setup(p => p.Apply(7, cheesePrice)).Returns(6.00);

            _dairyMilkPromoProcessor.Setup(p => p.Apply(1, dairyMilkPrice)).Returns(0.75);

            var posService = new PosService(_portfolio, _applePromoProcessor.Object, _biscuitPromoProcessor.Object,
                _cheesePromoProcessor.Object, _dairyMilkPromoProcessor.Object);

            var totalPrice = posService.Process("ABCDABA");
            Assert.Equal(13.25, totalPrice);

            totalPrice = posService.Process("CCCCCCC");
            Assert.Equal(6.00, totalPrice);

            totalPrice = posService.Process("ABCD");
            Assert.Equal(7.25, totalPrice);
        }
    }
}

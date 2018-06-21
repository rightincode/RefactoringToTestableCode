using Microsoft.VisualStudio.TestTools.UnitTesting;
using NonDeterministic;

namespace NonDeterministicTests
{
    [TestClass]
    public class PriceCalculatorTests
    {
        [TestMethod]
        public void CalculateFinalPriceBefore10AM_BasePriceTenDollars_FinalPriceEightDollars()
        {
            var myPriceCalculator = new Program.PriceCalculator();

            decimal result = myPriceCalculator.CalculateFinalPrice(10);

            Assert.AreEqual(decimal.Parse("8"), result);
        }

        [TestMethod]
        public void CalculateFinalPriceAfter10AMAndBefore12Noon_BasePriceTenDollars_FinalPriceNineDollars()
        {
            var myPriceCalculator = new Program.PriceCalculator();

            decimal result = myPriceCalculator.CalculateFinalPrice(10);

            Assert.AreEqual(decimal.Parse("9"), result);
        }
    }
}

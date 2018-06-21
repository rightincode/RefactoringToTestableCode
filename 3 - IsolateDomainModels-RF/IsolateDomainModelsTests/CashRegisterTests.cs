using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IsolateDomainModelsTests.Models;
using IsolateDomainModels.Models;

namespace TightCouplingTests
{
    [TestClass]
    public class CashRegisterTests
    {
        [TestMethod]
        public void CalculateFinalPricesBefore10AM_BasePricesFrom1To10_EachFinalPricesHas20PercentDiscount()
        {
            MockPriceDataRepository myPriceRepo = new MockPriceDataRepository();

            CashRegister cashRegister = new CashRegister(myPriceRepo, new DateTime(2018, 06, 21, 09, 00, 00)); //also processing
            
            decimal currentValue = 1;
            foreach (PricingRecord pricingRecord in cashRegister.PriceResults)
            {
                Assert.AreEqual(currentValue, pricingRecord.BasePrice);
                Assert.AreEqual((currentValue - (currentValue * decimal.Parse(".2"))), pricingRecord.FinalPrice);
                currentValue++;
            }
        }

        [TestMethod]
        public void CalculateFinalPricesAfter10AMBefore12Noon_BasePricesFrom1To10_EachFinalPricesHas10PercentDiscount()
        {
            MockPriceDataRepository myPriceRepo = new MockPriceDataRepository();

            CashRegister cashRegister = new CashRegister(myPriceRepo, new DateTime(2018, 06, 21, 11, 00, 00)); //also processing

            decimal currentValue = 1;
            foreach (PricingRecord pricingRecord in cashRegister.PriceResults)
            {
                Assert.AreEqual(currentValue, pricingRecord.BasePrice);
                Assert.AreEqual((currentValue - (currentValue * decimal.Parse(".1"))), pricingRecord.FinalPrice);
                currentValue++;
            }
        }

        [TestMethod]
        public void CalculateFinalPricesAfter12Noon_BasePricesFrom1To10_NoDiscounts()
        {
            MockPriceDataRepository myPriceRepo = new MockPriceDataRepository();

            CashRegister cashRegister = new CashRegister(myPriceRepo, new DateTime(2018, 06, 21, 12, 30, 00)); //also processing

            foreach (PricingRecord pricingRecord in cashRegister.PriceResults)
            {
                Assert.AreEqual(pricingRecord.BasePrice, pricingRecord.FinalPrice);
            }
        }
    }
}

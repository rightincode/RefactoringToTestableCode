using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TightCoupling;

[TestClass]
public class PriceCalculatorTests
{
    [TestMethod]
    public void CalculateFinalPriceBefore10AM_BasePriceTenDollars_FinalPriceEightDollars()
    {
        var myPriceCalculator = new Program.PriceCalculator();

        decimal result = myPriceCalculator.CalculateFinalPrice(10, new DateTime(2018, 06, 21, 09, 30, 00));

        Assert.AreEqual(decimal.Parse("8"), result);
    }

    [TestMethod]
    public void CalculateFinalPriceAfter10AMAndBefore12Noon_BasePriceTenDollars_FinalPriceNineDollars()
    {
        var myPriceCalculator = new Program.PriceCalculator();

        decimal result = myPriceCalculator.CalculateFinalPrice(10, new DateTime(2018, 06, 21, 11, 30, 00));

        Assert.AreEqual(decimal.Parse("9"), result);
    }

    [TestMethod]
    public void CalculateFinalPriceAfter3PM_BasePriceTenDollars_FinalPriceTenDollars()
    {
        var myPriceCalculator = new Program.PriceCalculator();

        decimal result = myPriceCalculator.CalculateFinalPrice(10, new DateTime(2018, 06, 21, 15, 30, 00));

        Assert.AreEqual(decimal.Parse("10"), result);
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TightCoupling
{
    public class Program
    {
        static void Main(string[] args)
        {
            var myCashRegister = new CashRegister();

            int lineNumber = 1;
            foreach(var priceResult in myCashRegister.PriceResults)
            {
                Debug.WriteLine(lineNumber.ToString() + ". The base price is " + priceResult.BasePrice.ToString("c") + 
                    " and the final price is " + priceResult.FinalPrice.ToString("c"));
                lineNumber++;
            }
        }        
    }

    public struct PricingRecord
    {
        public decimal BasePrice;
        public decimal FinalPrice;
    }

    public class CashRegister
    {
        readonly PriceDataRepository _priceDataRepo;
        readonly PriceCalculator _priceCalculator = new PriceCalculator();
        public readonly List<PricingRecord> PriceResults = new List<PricingRecord>();

        public CashRegister()
        {
            _priceDataRepo = new PriceDataRepository();

            foreach (var price in _priceDataRepo.PriceData)
            {
                var pricingRecord = new PricingRecord
                {
                    BasePrice = price,
                    FinalPrice = _priceCalculator.CalculateFinalPrice(price, DateTime.Now)
                };

                PriceResults.Add(pricingRecord);
            }
        }
    }

    public class PriceDataRepository
    {
        public List<decimal> PriceData { get; private set; }

        public PriceDataRepository()
        {
            PriceData = new List<decimal>();
            var randGenerator = new Random();

            for (int counter = 1; counter <= 10; counter++)
            {
                decimal newPrice = (decimal)(randGenerator.NextDouble() * 250);
                PriceData.Add(newPrice);
            }
        }
    }

    public class PriceCalculator
    {
        public decimal CalculateFinalPrice(decimal basePrice, DateTime currentTime)
        {
            decimal finalPrice = 0;

            finalPrice = currentTime.Hour < 10
                ? basePrice - (basePrice * decimal.Parse(".2"))
                : (currentTime.Hour >= 10) && (currentTime.Hour < 12) ? basePrice - (basePrice * decimal.Parse(".1"))
                : basePrice;

            return finalPrice;
        }
    }
}

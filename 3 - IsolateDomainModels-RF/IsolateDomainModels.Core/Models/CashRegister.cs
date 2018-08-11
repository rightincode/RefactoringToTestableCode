using System;
using System.Collections.Generic;

namespace IsolateDomainModels.Core.Models
{
    public struct PricingRecord
    {
        public decimal BasePrice;
        public decimal FinalPrice;
    }
    public class CashRegister
    {
        readonly PriceCalculator _priceCalculator = new PriceCalculator();
        public readonly List<PricingRecord> PriceResults = new List<PricingRecord>();

        public CashRegister(List<decimal> priceData, DateTime currentTime)
        {
            foreach (var price in priceData)
            {
                var pricingRecord = new PricingRecord
                {
                    BasePrice = price,
                    FinalPrice = _priceCalculator.CalculateFinalPrice(price, currentTime)
                };

                PriceResults.Add(pricingRecord);
            }
        }
    }
}

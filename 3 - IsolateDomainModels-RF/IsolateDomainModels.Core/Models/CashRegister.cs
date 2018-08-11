using System;
using System.Collections.Generic;
using IsolateDomainModels.Core.Interfaces;

namespace IsolateDomainModels.Core.Models
{
    public struct PricingRecord
    {
        public decimal BasePrice;
        public decimal FinalPrice;
    }
    public class CashRegister
    {
        readonly IPriceDataRepository _priceDataRepo;
        readonly PriceCalculator _priceCalculator = new PriceCalculator();
        public readonly List<PricingRecord> PriceResults = new List<PricingRecord>();

        public CashRegister(IPriceDataRepository priceDataRepository, DateTime currentTime)
        {
            _priceDataRepo = priceDataRepository;
            _priceDataRepo.CalulateFinalPrices();

            foreach (var price in _priceDataRepo.PriceData)
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

using System;

namespace IsolateDomainModels.Models
{
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

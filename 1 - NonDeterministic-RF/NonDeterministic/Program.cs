using System;
using System.Diagnostics;

namespace NonDeterministic
{
    public class Program
    {
        static void Main(string[] args)
        {
            var myPriceCalculator = new PriceCalculator();

            Debug.WriteLine("The base price is $10 and the final price is $"
                + myPriceCalculator.CalculateFinalPrice(10, DateTime.Now).ToString());
        }

        public class PriceCalculator
        {
            public decimal CalculateFinalPrice(decimal basePrice, DateTime currentTime)
            {
                decimal finalPrice = 0;

                if (currentTime.Hour < 10)
                {
                    finalPrice = basePrice - (basePrice * decimal.Parse(".2"));
                }
                else if ((currentTime.Hour >= 10) && (currentTime.Hour < 12))
                {
                    finalPrice = basePrice - (basePrice * decimal.Parse(".1"));
                }
                else
                {
                    finalPrice = basePrice;
                }

                //Same logic as above but using a conditional operator
                //finalPrice = currentTime.Hour < 10
                //    ? basePrice - (basePrice * decimal.Parse(".2"))
                //    : (currentTime.Hour >= 10) && (currentTime.Hour < 12) ? basePrice - (basePrice * decimal.Parse(".1")) 
                //    : basePrice;

                return finalPrice;
            }
        }
    }

    
}

using System;
using System.Diagnostics;
using IsolateDomainModels.Core.Models;
using IsolateDomainModels.Data.Models;

namespace IsolateDomainModels
{
    public class Program
    {
        static void Main(string[] args)
        {
            var priceDataRepo = new PriceDataRepository();
            priceDataRepo.CalulateFinalPrices();

            var myCashRegister = new CashRegister(priceDataRepo.PriceData, DateTime.Now);

            int lineNumber = 1;
            foreach (var priceResult in myCashRegister.PriceResults)
            {
                Debug.WriteLine(lineNumber.ToString() + ". The base price is " + priceResult.BasePrice.ToString("c") +
                    " and the final price is " + priceResult.FinalPrice.ToString("c"));
                lineNumber++;
            }
        }
    }    
}

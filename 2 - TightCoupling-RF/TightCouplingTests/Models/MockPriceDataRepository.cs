using System;
using System.Collections.Generic;
using System.Text;
using TightCoupling.Interfaces;

namespace TightCouplingTests.Models
{
    public class MockPriceDataRepository : IPriceDataRepository
    {
        public List<decimal> PriceData { get; private set; }

        public MockPriceDataRepository()
        {
            PriceData = new List<decimal>();

        }
        public void CalulateFinalPrices()
        {
            for(int currentPrice=1; currentPrice<=10; currentPrice++)
            {
                PriceData.Add((decimal)currentPrice);
            }
        }
    }
}

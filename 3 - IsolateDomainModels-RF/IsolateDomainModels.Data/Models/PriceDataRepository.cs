﻿using System;
using System.Collections.Generic;
using IsolateDomainModels.Data.Interfaces;

namespace IsolateDomainModels.Data.Models
{
    public class PriceDataRepository : IPriceDataRepository
    {
        public List<decimal> PriceData { get; private set; }
        public PriceDataRepository()
        {
            PriceData = new List<decimal>();
        }
        public void CalulateFinalPrices()
        {
            var randGenerator = new Random();

            for (int counter = 1; counter <= 10; counter++)
            {
                decimal newPrice = (decimal)(randGenerator.NextDouble() * 249 + 1);
                PriceData.Add(newPrice);
            }
        }
    }
}

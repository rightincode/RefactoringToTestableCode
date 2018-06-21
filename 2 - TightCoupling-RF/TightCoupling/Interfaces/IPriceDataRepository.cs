using System;
using System.Collections.Generic;
using System.Text;

namespace TightCoupling.Interfaces
{
    public interface IPriceDataRepository
    {
        List<decimal> PriceData { get; }

        void CalulateFinalPrices();
    }
}

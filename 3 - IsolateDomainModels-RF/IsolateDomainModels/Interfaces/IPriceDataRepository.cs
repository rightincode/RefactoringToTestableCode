using System;
using System.Collections.Generic;
using System.Text;

namespace IsolateDomainModels.Interfaces
{
    public interface IPriceDataRepository
    {
        List<decimal> PriceData { get; }

        void CalulateFinalPrices();
    }
}

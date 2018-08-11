using System.Collections.Generic;

namespace IsolateDomainModels.Data.Interfaces
{
    public interface IPriceDataRepository
    {
        List<decimal> PriceData { get; }

        void CalulateFinalPrices();
    }
}

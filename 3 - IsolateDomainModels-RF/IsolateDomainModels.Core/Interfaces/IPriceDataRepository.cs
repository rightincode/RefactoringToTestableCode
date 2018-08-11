using System.Collections.Generic;

namespace IsolateDomainModels.Core.Interfaces
{
    public interface IPriceDataRepository
    {
        List<decimal> PriceData { get; }

        void CalulateFinalPrices();
    }
}

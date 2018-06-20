using System.Diagnostics;

namespace NonDeterministic
{
    class Program
    {
        static void Main(string[] args)
        {
            var myPriceCalculator = new PriceCalculator();

            Debug.WriteLine("The base price is $10 and the final price is $" 
                + myPriceCalculator.CalculateFinalPrice(10).ToString());
        }
    }
}

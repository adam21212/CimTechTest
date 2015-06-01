

namespace TechTestCTM.Utility.IsPrime
{
    public static class Extention
    {
        static PrimeCalculator primeCalc = new PrimeCalculator();

        public static bool IsPrime(this int number)
        {
            return primeCalc.IsPrime(number);
        }
    }
}

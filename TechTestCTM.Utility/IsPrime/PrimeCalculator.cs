using System;
using System.Collections.Generic;

namespace TechTestCTM.Utility.IsPrime
{
    internal class PrimeCalculator
    {
        private Dictionary<int, bool> primeCache = new Dictionary<int, bool>();

        internal bool IsPrime(int number)
        {
            if (number < 3) return number == 2;
            if (number % 2 == 0) return false;
            if (primeCache.ContainsKey(number)) return primeCache[number];
            int limit = (int)Math.Floor(Math.Sqrt(number));
            int candidate;
            for (candidate = 3; number % candidate != 0 && candidate <= limit; candidate += 2) ;
            bool result = candidate > limit;
            primeCache.Add(number, result);
            return result;
        }
    }
}

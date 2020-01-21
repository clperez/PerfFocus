using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PrimeCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var primeNumber in GetNextPrimeNaive())
                Console.WriteLine(primeNumber);
        }


        // One core simd 
        // Multicore paralelization
        private static IEnumerable<long> GetNextPrimeNaive()
        {
            for (var currentValue = 1; ; currentValue++)
            {
                bool isPrime = true;
                for (var currentDenominator = 2; currentDenominator < currentValue; ++ currentDenominator)
                {
                    if (!(isPrime = currentValue % currentDenominator != 0)) break;
                }

                if (isPrime) yield return currentValue;
            }
        }
    }


}

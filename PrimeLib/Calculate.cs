using System;
using System.Collections.Generic;

namespace PrimeLib
{
    public class Calculate
    {
        // One core simd 
        // Multicore paralelization
        public static IEnumerable<long> Naive(long max)
        {
            for (int currentValue = 1; currentValue <= max; currentValue++)
            {
                bool isPrime = true;
                for (var currentDenominator = 2; currentDenominator < currentValue; ++currentDenominator)
                {
                    if (!(isPrime = currentValue % currentDenominator != 0)) break;
                }

                if (isPrime) yield return currentValue;
            }

            yield break;
        }

        public static IEnumerable<long> ImprovedAlgorithm(long max)
        {
            yield return 1;

            yield return 2;

            var floor = (long)Math.Floor(Math.Sqrt(max));
            
            for (int currentValue = 3; currentValue <= floor; currentValue +=2)
            {
                bool isPrime = true;

                if (!(isPrime = (currentValue % 2 != 0))) continue;
                else if (!(isPrime = (currentValue % 3 != 0))) continue;
                else
                {
                    for (var currentDenominator = 5; currentDenominator < currentValue; currentDenominator+=6)
                    {
                        if (!(isPrime = currentValue % currentDenominator != 0)) break;
                    }
                }

                if (isPrime) yield return currentValue;
            }

            yield break;
        }
    }
}

using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace PrimeCalculation
{
    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<PrimeBecnhmark>();

 ///           foreach (var i in PrimeLib.Calculate.Naive()) Console.WriteLine(i);
        }
    }

    public class PrimeBecnhmark
    {
        [Params(1000, 10000, 50000, 200000)]
        public long max;

        private long pingInterval = 10000;
        private StreamWriter _naiveOutput;
        private StreamWriter _algorithmsOutput;

        [GlobalSetup]
        public void Setup ()
        {
            _naiveOutput = new StreamWriter("naive.txt");
            _algorithmsOutput = new StreamWriter("algor.txt");
        }
        
        [Benchmark]
        public void RunBenchmarkNaive() => RunBenchmark(_naiveOutput, PrimeLib.Calculate.Naive);
        
        [Benchmark]
        public void RunBenchmarkAlgorithm() => RunBenchmark(_algorithmsOutput, PrimeLib.Calculate.ImprovedAlgorithm);

        public void RunBenchmark(StreamWriter writer, Func<long, IEnumerable<long>> function) => Run(max, pingInterval, writer, function);

        public static void Run (long ceiling, long pingInterval, StreamWriter writer, Func<long,IEnumerable<long>> function)
        {
            foreach (var i in function(ceiling))
            {
                if (i % pingInterval == 0)
                    Console.WriteLine($"Processed {i}");
                writer.WriteLine(i);
            }
        }
    }


}

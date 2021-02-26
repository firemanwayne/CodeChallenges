using CodeChallenge.Chapter1;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {               
            var values = GenerateSmallList();
            var largeValues = GenerateLargeList();

            var result = values.TruncatedMean(RandomDiscard());
            WriteLine($"Truncated Int Result: {result}\n\n");

            var doubleResult = values.TruncatedMean(RandomDoubleDiscard());
            WriteLine($"Truncated Double Result: {doubleResult}\n\n");

            var medianResult = largeValues.Median();

            WriteLine($"Median Result: {medianResult}\n\n");

            var modeResult = largeValues.Mode();

            foreach (var m in modeResult)
                WriteLine($"Mode Result: {m} has the most occurances");

            var standardDeviationPop = largeValues.StandardDeviation();
            var standardDeviationSample = largeValues.StandardDeviation();

            WriteLine($"Standard Deviation Population: {standardDeviationPop}");
            WriteLine($"Standard Deviation Population: {standardDeviationSample}");

            Console.ReadKey();
        }

        static readonly Func<IEnumerable<int>> GenerateLargeList = ()
            => Enumerable.Range(100, 1000)
                .Select(a => new Random().Next(100, 1000));

        static readonly Func<IEnumerable<int>> GenerateSmallList = ()
            => Enumerable.Range(0, 100)
                .Select(a => new Random().Next(0, 100));

        static readonly Func<int> RandomDiscard = ()
            => new Random().Next(1, 5);

        static readonly Func<double> RandomDoubleDiscard = ()
            => new Random().NextDouble();
    }
}

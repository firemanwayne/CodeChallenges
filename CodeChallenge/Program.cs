using CodeChallenge.Chapter1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {               
            var values = SmallList();
            var largeValues = LargeList();

            var result = values.TruncatedMean(RandomDiscard());
            Console.WriteLine($"Truncated Int Result: {result}\n\n");

            var doubleResult = values.TruncatedMean(RandomDoubleDiscard());
            Console.WriteLine($"Truncated Double Result: {doubleResult}\n\n");

            var medianResult = largeValues.Median();

            Console.WriteLine($"Median Result: {medianResult}\n\n");

            Console.ReadKey();
        }

        static readonly Func<IEnumerable<int>> LargeList = ()
            => Enumerable.Range(100, 1000)
                .Select(a => new Random().Next(100, 1000));

        static readonly Func<IEnumerable<int>> SmallList = ()
            => Enumerable.Range(0, 100)
                .Select(a => new Random().Next(0, 100));

        static readonly Func<int> RandomDiscard = ()
            => new Random().Next(1, 5);

        static readonly Func<double> RandomDoubleDiscard = ()
            => new Random().NextDouble();
    }
}

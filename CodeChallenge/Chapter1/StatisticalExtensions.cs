using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CodeChallenge.Chapter1
{
    public static class StatisticalExtensions
    {
        public static double TruncatedMean<T>(this IEnumerable<T> values, int discard)
        {
            var doubles = values.Select(a => Convert.ToDouble(a))
                .OrderBy(a => a)
                .ToArray();

            int minIndex = discard;
            int maxIndex = doubles.Length - 1 - discard;

            int remaining = maxIndex - minIndex + 1;

            var resultArray = new double[remaining];

            Array.Copy(doubles, minIndex, resultArray, 0, remaining);

            return resultArray.Average();
        }
        public static double TruncatedMean<T>(this IEnumerable<T> values, double discard)
        {
            var discardInt = (int)(values.Count() * discard);

            return TruncatedMean(values, discardInt);
        }
        public static double Median<T>(this IEnumerable<T> values)
        {
            var doubles = values               
                .Select(a => Convert.ToDouble(a))
                .OrderBy(a => a)
                .ToArray();

            var valuesCount = doubles.Length;

            if (valuesCount % 2 == 1)
            {
                WriteLine($"Total Items: {valuesCount}");

                return doubles[valuesCount / 2];
            }
            else
            {
                var leftValue = doubles[valuesCount / 2 - 1];
                var rightValue = doubles[valuesCount / 2];

                WriteLine($"Total Items: {valuesCount}");
                WriteLine($"Left Value: {leftValue}");
                WriteLine($"Right Value: {rightValue}");

                return (leftValue + rightValue) / 2.0;
            }
        }

        public static double Mode<T>(this IEnumerable<T> values)
        {
            var doubles = values
                .Select(a => Convert.ToDouble(a))
                .GroupBy(a => a)
                .Select(a => a)
                .ToList();                

            foreach(var d in doubles)
            {
                
            }
        }
    }
}

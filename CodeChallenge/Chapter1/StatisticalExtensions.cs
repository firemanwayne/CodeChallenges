using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CodeChallenge.Chapter1
{
    public static class StatisticalExtensions
    {
        /// <summary>
        /// Returns the average after removing an indicated number of the largest and smallest values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="discard"></param>
        /// <returns></returns>
        public static double TruncatedMean<T>(this IEnumerable<T> values, int discard)
        {
            var doubles = values.Select(a => Convert.ToDouble(a))
                .OrderBy(a => a)
                .ToArray();

            int minIndex = discard;
            int maxIndex = doubles.Length - 1 - discard;

            int remaining = maxIndex - minIndex + 1;

            if (remaining < 0)
                return 0;

            var resultArray = new double[remaining];

            Array.Copy(doubles, minIndex, resultArray, 0, remaining);

            return resultArray.Average();
        }
        /// <summary>
        /// Returns the average after removing an indicated percentage of the largest and smallest values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="discard"></param>
        /// <returns></returns>
        public static double TruncatedMean<T>(this IEnumerable<T> values, double discard)
        {
            var discardInt = (int)(values.Count() * discard);

            return TruncatedMean(values, discardInt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
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

        public static List<T> Mode<T>(this IEnumerable<T> values)
        {
            IDictionary<T, int> valueDictionary = new Dictionary<T, int>();                

            foreach(var d in values)
            {
                if (valueDictionary.ContainsKey(d))
                    valueDictionary[d]++;
                else
                    valueDictionary.TryAdd(d, 1);
            }

            var maxValue = valueDictionary.Values.Max();

            var returnValues = valueDictionary
                .Where(a => a.Value.Equals(maxValue))
                .ToList();                

            foreach (var v in returnValues)
                WriteLine($"Key: {v.Key} Count: {v.Value}");

            return returnValues
                .Select(a => a.Key)
                .ToList();
        }
        public static double StandardDeviation<T>(this IEnumerable<T> values, bool asSample = false)
        {
            var doubleValues = values.Select(a => Convert.ToDouble(a));

            var doubleCount = doubleValues.Count();

            var mean = doubleValues.Average();

            var squaresQuery = from double value in doubleValues select (value - mean) * (value - mean);

            var sumOfSquares = squaresQuery.Sum();

            if (asSample)
                return Math.Sqrt(sumOfSquares / (doubleCount - 1));

            return Math.Sqrt(sumOfSquares / doubleCount);
        }
    }
}

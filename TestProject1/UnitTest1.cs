using ChallengeUnitTests;
using CodeChallenge.Extensions;
using System;
using System.Linq;
using Xunit;
using static System.Console;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var originalList = InLineStaticData.Get();

            var originalCount = originalList.Length;

            WriteLine($"Starting Count: {originalCount}");

            var duplicateFreeList = originalList
                .RemoveDuplicates();

            var newCount = duplicateFreeList.Count();

            WriteLine($"Starting Count: {newCount}");

            Assert.NotEqual(expected: originalCount, actual: newCount);
        }
    }
}

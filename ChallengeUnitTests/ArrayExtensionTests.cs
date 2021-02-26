using CodeChallenge.Extensions;
using System.Linq;
using Xunit;
using static System.Console;

namespace ChallengeUnitTests
{
    public class ArrayExtensionTests
    {
        [Fact]
        public void Test_RemoveDuplicates()
        {
            WriteLine($"Starting Count: {InLineStaticData.Get().Length}");

            var duplicateFreeList = InLineStaticData
                .Get()
                .RemoveDuplicates();

            WriteLine($"Ending Count: {duplicateFreeList.Count()}");

            Assert.False(InLineStaticData.Get().Length == duplicateFreeList.Count());
        }
    }

    public static class InLineStaticData
    {
        public static int[] Get()
        {
            return new []{ 1, 1, 1, 2, 3, 4, 4, 6, 7, 8, 8, 9 };
        }       
    }
}

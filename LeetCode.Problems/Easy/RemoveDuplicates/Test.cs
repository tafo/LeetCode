using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Easy.RemoveDuplicates
{
    public class Test
    {
        private readonly ITestOutputHelper _outputHelper;

        public Test(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[]{1,1,2}, new[]{1,2,2}, 2
            },
            new object[]
            {
                new[]{0,0,1,1,1,2,2,3,3,4}, new[]{0,1,2,3,4,2,2,3,3,4}, 5
            },
        };

        [Theory]
        [MemberData(nameof(InputAndOutput))]
        public void Check(int[] numbers, int[] expectedNumbers, int k)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            var actualOutput = solution.RemoveDuplicates(numbers);
            timer.Stop();

            Assert.Equal(k, actualOutput);

            for (var i = 0; i < actualOutput; i++)
            {
                Assert.Equal(expectedNumbers[i], numbers[i]);
            }

            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }
    }
}
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.ContainerWithMostWater
{
    public class Test
    {
        private readonly ITestOutputHelper _outputHelper;
        
        public Test(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Theory]
        [MemberData(nameof(InputAndOutput))]
        public void Check(int[] heights, int expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.MaxArea(heights);
            timer.Stop();
            actualOutput.Should().Be(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[] {1, 8, 6, 2, 5, 4, 8, 3, 7}, 49
            },
            new object[]
            {
                new[] {1, 1}, 1
            },
            new object[]
            {
                new[] {4, 3, 2, 1, 4}, 16
            },
            new object[]
            {
                new[] {1, 2, 1}, 2
            },
        };
    }
}
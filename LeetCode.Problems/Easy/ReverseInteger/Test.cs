using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Easy.ReverseInteger
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
            new object[]{123, 321},
            new object[]{1230, 321},
            new object[]{-123, -321},
            new object[]{120, 021},
            new object[]{0, 0},
            new object[]{1534236469, 0},
        };

        [Theory]
        [MemberData(nameof(InputAndOutput))]
        public void Check(int number, int expectedOutput)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            var actualOutput = solution.Reverse(number);
            timer.Stop();
            actualOutput.Should().Be(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }
    }
}
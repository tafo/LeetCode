using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.Divide
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
        public void Check(int divident, int divisor, int expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.Divide(divident, divisor);
            timer.Stop();
            actualOutput.Should().Be(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                16, 2, 8
            },
            new object[]
            {
                10, 3, 3
            },
            new object[]
            {
                10, -3, -3
            },
            new object[]
            {
                -10, 3, -3
            },
            new object[]
            {
                -10, -3, 3
            },
            new object[]
            {
                1, 1, 1
            },
            new object[]
            {
                1, -1, -1
            },
            new object[]
            {
                -1, 1, -1
            },
            new object[]
            {
                -1, -1, 1
            },
            new object[]
            {
                -2147483648, -1, 2147483647
            },
            new object[]
            {
                -2147483648, 1, -2147483648
            },
            new object[]
            {
                -2147483648, 2, -1073741824
            },
        };
    }
}
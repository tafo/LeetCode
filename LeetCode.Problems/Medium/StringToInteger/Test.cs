using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.StringToInteger
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
        public void Check(string input, int expectedOutput)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            var actualOutput = solution.MyAtoi(input);
            timer.Stop();
            actualOutput.Should().Be(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[] {"42", 42},
            new object[] {"    -42", -42},
            new object[] {"4193 with words", 4193},
            new object[] {"words and 987", 0},
            new object[] {"-91283472332", -2147483648},
            new object[] {"    999991283472332", 2147483647},
            new object[] {"+1", 1},
            new object[] {"+-12", 0},
            new object[] {"00000-42a1234", 0},
        };
    }
}
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Easy.RomanToInteger
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
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
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.RomanToInt(input);
            timer.Stop();
            actualOutput.Should().Be(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                "III", 3
            },
            new object[]
            {
                "IV", 4
            },
            new object[]
            {
                "IX", 9
            },
            new object[]
            {
                "LVIII", 58
            },
            new object[]
            {
                "MCMXCIV", 1994
            },
        };
    }
}
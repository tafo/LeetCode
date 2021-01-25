using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.IntegerToRoman
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
        public void Check(int num, string expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.IntToRoman(num);
            timer.Stop();
            actualOutput.Should().Be(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                3, "III"
            },
            new object[]
            {
                4, "IV"
            },
            new object[]
            {
                9, "IX"
            },
            new object[]
            {
                58, "LVIII"
            },
            new object[]
            {
                1994, "MCMXCIV"
            },
        };
    }
}
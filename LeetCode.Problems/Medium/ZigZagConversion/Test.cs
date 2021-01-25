using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.ZigZagConversion
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
        public void Check(string input, int numberOfRows, string expectedOutput)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            var actualOutput = solution.Convert(input, numberOfRows);
            timer.Stop();
            actualOutput.Should().Be(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static  IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]{"PAYPALISHIRING", 3, "PAHNAPLSIIGYIR"},
            new object[]{"PAYPALISHIRING", 4, "PINALSIGYAHRPI"},
            new object[]{"PAYPALISHIRING", 5, "PHASIYIRPLIGAN"},
            new object[]{"ABC", 1, "ABC"},
            new object[]{"ABC", 2, "ACB"},
        };
    }
}
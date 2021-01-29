using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.LetterCombinations
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
        public void Check(string phoneNumber, IEnumerable<string> expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.LetterCombinations(phoneNumber);
            timer.Stop();
            actualOutput.Should().BeEquivalentTo(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                "23", new List<string> {"ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"}
            },
            new object[]
            {
                "", new List<string>()
            },
            new object[]
            {
                "2", new List<string> {"a", "b", "c"}
            },
        };
    }
}
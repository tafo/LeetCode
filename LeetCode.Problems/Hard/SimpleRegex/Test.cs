using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Hard.SimpleRegex
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
        public void Check(string text, string pattern, bool expectedOutput)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            var actualOutput = solution.IsMatch(text, pattern);
            timer.Stop();
            actualOutput.Should().Be(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static  IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]{"aa", "abc", false},
            new object[]{"aa", "a", false},
            new object[]{"aa", "a*", true},
            new object[]{"ab", ".*", true},
            new object[]{"aab", "c*a*b", true},
            new object[]{"aaa", "a*a", true},
        };
    }
}
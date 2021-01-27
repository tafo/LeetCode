using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Easy.LongestCommonPrefix
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
        public void Check(string[] stringList, string expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.LongestCommonPrefix(stringList);
            timer.Stop();
            actualOutput.Should().Be(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[] {"flower","flow","flight"}, "fl"
            },
            new object[]
            {
                new[] {"dog","racecar","car"}, string.Empty
            },
        };

    }
}
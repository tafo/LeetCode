using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Easy.ValidParantheses
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
        public void Check(string input, bool expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.IsValid(input);
            timer.Stop();
            actualOutput.Should().Be(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                "()", true
            },
            new object[]
            {
                "()[]{}", true
            },
            new object[]
            {
                "(]", false
            },
            new object[]
            {
                "([)]", false
            },
            new object[]
            {
                "{[]}", true
            },
            new object[]
            {
                "{()[()]}", true
            },
            new object[]
            {
                "({[)", false
            },
        };
    }
}
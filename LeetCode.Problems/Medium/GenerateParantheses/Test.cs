using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using LeetCode.Problems.Common;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.GenerateParantheses
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
        public void Check(int n, IList<string> expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.GenerateParenthesis(n);
            timer.Stop();
            actualOutput.Should().BeEquivalentTo(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                1,
                new List<string> {"()"}
            },
            new object[]
            {
                2,
                new List<string> {"(())", "()()"}
            },
            new object[]
            {
                3,
                new List<string> {"((()))", "(()())", "(())()", "()(())", "()()()"}
            },
            new object[]
            {
                4,
                new List<string>
                {
                    "(((())))", "((()()))", "((())())", "((()))()", "(()(()))", "(()()())", "(()())()", "(())(())",
                    "(())()()", "()((()))", "()(()())", "()(())()", "()()(())", "()()()()"
                }
            },
        };
    }
}
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using LeetCode.Problems.Common;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.FourSum
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
        public void Check(int[] numbers, int target, IList<IList<int>> expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.FourSum(numbers, target);
            timer.Stop();
            actualOutput.Should().BeEqualTo(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[] {1, 0, -1, 0, -2, 2},
                0,
                new List<IList<int>>
                {
                    new List<int>
                    {
                        -2, -1, 1, 2
                    },
                    new List<int>
                    {
                        -2, 0, 0, 2
                    },
                    new List<int>
                    {
                        -1, 0, 0, 1
                    }
                }
            },
            new object[]
            {
                new int[] { },
                0,
                new List<IList<int>>()
            },
        };
    }
}
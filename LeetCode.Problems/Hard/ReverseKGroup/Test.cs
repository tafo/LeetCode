using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using LeetCode.Problems.Common;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Hard.ReverseKGroup
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
        public void Check(ListNode node, int k, IEnumerable<int> expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.ReverseKGroup(node, k);
            timer.Stop();
            actualOutput.ToList().Should().BeEqualTo(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[] {1, 2, 3, 4, 5}.ToListNode(),
                3,
                new List<int> {3, 2, 1, 4, 5}
            },
            new object[]
            {
                new[] {1, 2, 3, 4, 5}.ToListNode(),
                1,
                new List<int> {1, 2, 3, 4, 5}
            },
            new object[]
            {
                new[] {1}.ToListNode(),
                1,
                new List<int> {1}
            },

            new object[]
            {
                new[] {1, 2}.ToListNode(),
                2,
                new List<int> {2, 1}
            },
        };
    }
}
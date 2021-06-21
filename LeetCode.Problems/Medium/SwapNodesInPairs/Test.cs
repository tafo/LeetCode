using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using LeetCode.Problems.Common;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.SwapNodesInPairs
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
        public void Check(ListNode head, ListNode expectedHead)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualHead = solution.SwapPairs2(head);
            actualHead.IsEqualTo(expectedHead).Should().BeTrue();
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[] {1,2,3,4}.ToListNode(),
                new[] {2,1,4,3}.ToListNode()
            },
            new object[]
            {
                new[] {1}.ToListNode(),
                new[] {1}.ToListNode()
            }
        };
    }
}
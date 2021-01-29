using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using LeetCode.Problems.Common;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.RemoveNthNodeFromEndOfList
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
        public void Check(ListNode head, int n, ListNode expectedHead)
        {
            var timer = Stopwatch.StartNew();
            var solution = new SolutionWithStoring();
            timer.Start();
            var actualHead = solution.RemoveNthFromEnd(head, n);
            timer.Stop();
            actualHead.IsEqualTo(expectedHead).Should().BeTrue();
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new List<int> {1, 2, 3, 4, 5}.ToListNode(), 2, new List<int> {1, 2, 3, 5}.ToListNode()
            },
            new object[]
            {
                new List<int> {1}.ToListNode(), 1, new List<int>().ToListNode()
            },
            new object[]
            {
                new List<int> {1, 2}.ToListNode(), 1, new List<int> {1}.ToListNode()
            },
            new object[]
            {
                new List<int> {1, 2}.ToListNode(), 2, new List<int> {2}.ToListNode()
            },
            new object[]
            {
                new List<int> {1, 2, 3}.ToListNode(), 1, new List<int> {1, 2}.ToListNode()
            },
        };
    }
}
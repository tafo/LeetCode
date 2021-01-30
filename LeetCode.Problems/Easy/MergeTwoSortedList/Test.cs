using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using LeetCode.Problems.Common;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Easy.MergeTwoSortedList
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
        public void Check(ListNode l1, ListNode l2, ListNode expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new SolutionWithRecursion();
            timer.Start();
            var actualOutput = solution.MergeTwoLists(l1, l2);
            timer.Stop();
            actualOutput.IsEqualTo(expectedOutput).Should().BeTrue();
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[] {1, 2, 4}.ToListNode(),
                new[] {1, 3, 4}.ToListNode(), 
                new[] {1, 1, 2, 3, 4, 4}.ToListNode(),
            },
            new object[]
            {
                new int[] { }.ToListNode(), new int[] { }.ToListNode(), new int[] { }.ToListNode()
            },
            new object[]
            {
                new int[] { }.ToListNode(), new[] {0}.ToListNode(), new[] {0}.ToListNode()
            }
        };
    }
}
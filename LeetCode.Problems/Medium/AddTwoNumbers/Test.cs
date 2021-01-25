using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using LeetCode.Problems.Common;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.AddTwoNumbers
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
        public void Check(int[] leftValues, int[] rightValues, ListNode expectedHead)
        {
            var timer = Stopwatch.StartNew();
            timer.Start();
            var solution = new Solution();
            var leftHead = leftValues.ToListNode();
            var rightHead = rightValues.ToListNode();
            var resultHead = solution.AddTwoNumbers(leftHead, rightHead);
            timer.Stop();
            resultHead.IsEqualTo(expectedHead).Should().BeTrue();
            _outputHelper.WriteLine($"{timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput()
        {
            return new List<object[]>
            {
                new object[] {new[] {2, 4, 3}, new[] {5, 6, 4}, new[] {7, 0, 8}.ToListNode()},
                new object[] {new[] {5}, new[] {5}, new[] {0,1}.ToListNode()},
            };
        }
    }
}
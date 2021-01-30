﻿using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using LeetCode.Problems.Common;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Hard.MergeKSortedList
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
        public void Check(ListNode[] nodes, IEnumerable<int> expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.MergeKLists(nodes);
            timer.Stop();
            actualOutput.ToList().Should().BeEqualTo(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[] {new[] {-5, 10, 15}.ToListNode()},
                new List<int> {-5, 10, 15}
            },
            new object[]
            {
                new[] {new[] {-5, 10, 15}.ToListNode(), new[] {1, 2, 20}.ToListNode()},
                new List<int> {-5, 1, 2, 10, 15, 20}
            },
            new object[] {new ListNode[] { }, null}
        };
    }
}
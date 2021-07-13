using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.NextPermutation
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
        public void Check(int[] nums, int[] expectedNums)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            solution.NextPermutation(nums);
            timer.Stop();
            nums.SequenceEqual(expectedNums).Should().BeTrue();
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[] {1, 2, 3, 4, 5},
                new[] {1, 2, 3, 5, 4},
            },
            new object[]
            {
                new[] {1, 2, 3, 5, 4},
                new[] {1, 2, 4, 3, 5},
            },
            new object[]
            {
                new[] {1, 2, 4, 3, 5},
                new[] {1, 2, 4, 5, 3},
            },
            new object[]
            {
                new[] {1, 2, 4, 5, 3},
                new[] {1, 2, 5, 3, 4},
            },
            new object[]
            {
                new[] {1, 2, 9, 5, 4},
                new[] {1, 4, 2, 5, 9},
            },
            new object[]
            {
                new[] {2, 3, 1},
                new[] {3, 1, 2},
            },
        };
    }
}

using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeetCode.Problems.Easy.TwoSum
{
    public class Test
    {
        [Theory]
        [MemberData(nameof(InputAndOutput))]
        public void CheckLinq(int[] numbers, int target, int[] expectedOutput)
        {
            new Solution().TwoSum(numbers, target).Should().BeEquivalentTo(expectedOutput);
        }

        public static IEnumerable<object[]> InputAndOutput()
        {
            return new List<object[]>
            {
                new object[] {new[] {3, 3}, 6, new[] {0, 1}},
                new object[] {new[] {3, 2, 3}, 6, new[] {0, 2}},
                new object[] {new[] {3, 2, 4}, 6, new[] {1, 2}},
                new object[] {new[] {2, 7, 11, 15}, 9, new[] {0, 1}},
            };
        }
    }
}
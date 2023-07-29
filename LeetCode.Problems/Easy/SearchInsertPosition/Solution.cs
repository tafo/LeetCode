using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeetCode.Problems.Easy.SearchInsertPosition;

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target || nums[i] > target)
            {
                return i;
            }
        }

        return nums.Length;
    }
}

public class Test
{
    [Theory]
    [MemberData(nameof(InputAndOutput))]
    public void Check(int[] nums, int target, int expectedResult)
    {
        var solution = new Solution();
        var actualResult = solution.SearchInsert(nums, target);
        actualResult.Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> InputAndOutput => new List<object[]>
    {
        new object[]
        {
            new[] {1, 3, 5, 6},
            5,
            2
        },
        new object[]
        {
            new[] {1, 3, 5, 6},
            2,
            1
        },
    };
}
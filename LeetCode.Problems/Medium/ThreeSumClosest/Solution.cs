using System;

namespace LeetCode.Problems.Medium.ThreeSumClosest
{
    /// <summary>
    /// Problem: https://leetcode.com/problems/3sum-closest/
    /// </summary>
    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            var result = nums[0] + nums[1] + nums[2];
            if (target <= result) return result;
            for (var a = 0; a < nums.Length - 2; a++)
            {
                var c = nums.Length - 1;
                for (var b = a + 1; b < nums.Length - 1; b++)
                {
                    for (; b < c; c--)
                    {
                        var sum = nums[a] + nums[b] + nums[c];

                        if (Math.Abs(sum - target) < Math.Abs(result - target)) result = sum;
                        if (sum < target) break;
                        if (sum == target) return sum;
                    }
                }
            }

            return result;
        }
    }
}
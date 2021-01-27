using System;
using System.Collections.Generic;

namespace LeetCode.Problems.Medium.ThreeSum
{
    /// <summary>
    /// Problem: https://leetcode.com/problems/3sum/ 
    /// </summary>
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            for (var a = 0; a < nums.Length - 2; a++)
            {
                if (a > 0 && nums[a] == nums[a - 1]) continue;
                var c = nums.Length - 1;
                for (var b = a + 1; b < c; b++)
                {
                    if (b > a + 1 && nums[b] == nums[b - 1]) continue;
                    for (; b < c; c--)
                    {
                        if (c + 1 < nums.Length && nums[c + 1] == nums[c]) continue;
                        if (nums[a] + nums[b] + nums[c] < 0) break;
                        if (nums[a] + nums[b] + nums[c] > 0) continue;
                        result.Add(new List<int> { nums[a], nums[b], nums[c] });
                    }
                }
            }

            return result;
        }
    }
}
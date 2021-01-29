using System;
using System.Collections.Generic;

namespace LeetCode.Problems.Medium.FourSum
{
    /// <summary>
    /// Problem: https://leetcode.com/problems/4sum/
    /// </summary>
    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            for (var a = 0; a < nums.Length - 3; a++)
            {
                if (a > 0 && nums[a] == nums[a - 1]) continue;
                for (var b = a + 1; b < nums.Length - 2; b++)
                {
                    if (b > a + 1 && nums[b] == nums[b - 1]) continue;
                    var right = nums.Length - 1;
                    for (var c = b + 1; c < right; c++)
                    {
                        if (nums[a] + nums[b] + nums[c] + nums[c + 1] > target) break;
                        if (c > b + 1 && nums[c] == nums[c - 1]) continue;
                        var left = c + 1;
                        while (left <= right)
                        {
                            var d = (left + right) >> 1;
                            if (nums[a] + nums[b] + nums[c] + nums[d] < target)
                            {
                                left = d + 1;
                            }
                            else if (nums[a] + nums[b] + nums[c] + nums[d] > target)
                            {
                                right = d - 1;
                            }
                            else
                            {
                                result.Add(new List<int> { nums[a], nums[b], nums[c], nums[d] });
                                right = d - 1;
                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;

namespace LeetCode.Problems.Easy.TwoSum
{
    /// <summary>
    /// https://leetcode.com/problems/two-sum/
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// Runtime: 232 ms, faster than 99.41% of C# online submissions for Two Sum.
        /// Memory Usage: 30.7 MB, less than 63.14% of C# online submissions for Two Sum.
        /// </summary>
        public int[] TwoSum(int[] nums, int target)
        {
            var set = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var number = nums[i];
                if (set.ContainsKey(target - number))
                {
                    return new[] { set[target - number], i };
                }

                if (!set.ContainsKey(number))
                {
                    set.Add(number, i);
                }
            }

            throw new ArgumentException();
        }
    }
}
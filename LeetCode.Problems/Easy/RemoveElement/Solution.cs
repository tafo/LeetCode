using System;

namespace LeetCode.Problems.Easy.RemoveElement
{
    /// <summary>
    /// https://leetcode.com/problems/remove-element/
    /// </summary>
    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            var counter = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    nums[i] = -1;
                    counter++;
                }
                else
                {
                    var index = Array.FindIndex(nums, x => x == -1);
                    if (index > -1)
                    {
                        nums[index] = nums[i];
                        nums[i] = -1;
                    }
                }
            }

            return nums.Length - counter;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Medium.NextPermutation
{
    public class Solution
    {
        public void NextPermutation(int[] nums)
        {
            int i;
            for (i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])
                {
                    break;
                }
            }

            if (i == -1)
            {
                Array.Reverse(nums);
                return;
            }

            for (var j = nums.Length - 1; j >= 0; j--)
            {
                if (nums[j] > nums[i])
                {
                    var temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    break;
                }
            }

            Array.Reverse(nums, i + 1, nums.Length - i - 1);
        }
    }
}

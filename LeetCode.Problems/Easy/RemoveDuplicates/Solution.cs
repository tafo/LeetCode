namespace LeetCode.Problems.Easy.RemoveDuplicates
{
    /// <summary>
    /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
    /// </summary>
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return 1;

            var index = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[index] == nums[i])
                {
                    continue;
                }

                index++;
                nums[index] = nums[i];
            }

            return index + 1;
        }
    }
}
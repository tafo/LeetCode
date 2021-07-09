namespace LeetCode.Problems.Easy.RemoveElement
{
    /// <summary>
    /// https://leetcode.com/problems/remove-element/
    /// </summary>
    public class SolutionBest
    {
        public int RemoveElement(int[] nums, int val)
        {
            var counter = 0;
 
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val) nums[counter++] = nums[i];
            }

            return counter;
        }
    }
}
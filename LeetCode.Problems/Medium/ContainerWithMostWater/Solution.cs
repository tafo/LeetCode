using System;

namespace LeetCode.Problems.Medium.ContainerWithMostWater
{
    /// <summary>
    ///
    /// Problem >>> https://leetcode.com/problems/container-with-most-water/
    ///
    /// Time Complexity = O(n)
    /// Space Complexity = O(1)
    /// 
    /// </summary>
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            var minIndex = 0;
            var maxIndex = height.Length - 1;
            var output = 0;
            while (minIndex < maxIndex)
            {
                var area = Math.Min(height[minIndex], height[maxIndex]) * (maxIndex - minIndex);
                if (area > output)
                {
                    output = area;
                }

                if (height[minIndex] < height[maxIndex])
                {
                    minIndex++;
                }
                else
                {
                    maxIndex--;
                }
            }

            return output;
        }
    }
}
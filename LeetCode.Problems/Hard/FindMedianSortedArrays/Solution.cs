namespace LeetCode.Problems.Hard.FindMedianSortedArrays
{
    public class Solution
    {
        /// <summary>
        /// Runtime: 108 ms, faster than 98.69% of C# online submissions for Median of Two Sorted Arrays.
        /// Memory Usage: 27.5 MB, less than 92.70% of C# online submissions for Median of Two Sorted Arrays.
        /// </summary>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double output;
            var size = nums1.Length + nums2.Length;
            var middlePosition = size / 2;
            var leftIndex = 0;
            var rightIndex = 0;
            var middleElements = new double[2];
            var medianIndex = 0;
            var counter = 0;
            while (counter <= middlePosition)
            {
                if (leftIndex == nums1.Length)
                {
                    middleElements[medianIndex] = nums2[rightIndex++];
                    medianIndex = 1 - medianIndex;
                    counter++;
                    continue;
                }

                if (rightIndex == nums2.Length)
                {
                    middleElements[medianIndex] = nums1[leftIndex++];
                    medianIndex = 1 - medianIndex;
                    counter++;
                    continue;
                }

                if (nums1[leftIndex] < nums2[rightIndex])
                {
                    middleElements[medianIndex] = nums1[leftIndex++];
                    medianIndex = 1 - medianIndex;
                    counter++;
                    continue;
                }

                middleElements[medianIndex] = nums2[rightIndex++];
                medianIndex = 1 - medianIndex;
                counter++;
            }

            if ((size & 1) == 1)
            {
                output = ((size / 2) & 1) == 1 ? middleElements[1] : middleElements[0];
            }
            else
            {
                output = (middleElements[0] + middleElements[1]) / 2;
            }

            return output;
        }
    }
}
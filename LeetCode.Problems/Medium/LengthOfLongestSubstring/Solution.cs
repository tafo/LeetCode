using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems.Medium.LengthOfLongestSubstring
{
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// Runtime: 72 ms, faster than 99.28% of C# online submissions for Longest Substring.
        /// Memory Usage: 25.2 MB, less than 92.23% of C# online submissions for Longest Substring.
        /// </summary>
        public int LengthOfLongestSubstring(string s)
        {
            var startPosition = 0;
            var resultList = new List<int>();
            for (var i = 1; i < s.Length; i++)
            {
                var index = s.IndexOf(s[i], startPosition, i - startPosition);
                if (index == -1) continue;

                resultList.Add(i - startPosition);
                startPosition = index + 1;
            }

            resultList.Add(s.Length - startPosition);
            return resultList.Max();
        }
    }
}
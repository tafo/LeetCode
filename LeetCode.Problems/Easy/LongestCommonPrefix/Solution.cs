using System.Linq;

namespace LeetCode.Problems.Easy.LongestCommonPrefix
{
    /// <summary>
    /// Problem: https://leetcode.com/problems/longest-common-prefix/
    ///
    /// ToDo: Check Time Complexity
    /// ToDo: Check Space Complexity
    /// </summary>
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            return strs
                .DefaultIfEmpty("")
                .Aggregate((x, y) => x == "" ? "" : string.Concat(x.TakeWhile((c, i) => i < y.Length && c == y[i])));
        }
    }
}
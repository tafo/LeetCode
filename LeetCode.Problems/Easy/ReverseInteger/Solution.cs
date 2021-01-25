using System.Linq;

namespace LeetCode.Problems.Easy.ReverseInteger
{
    /// <summary>
    ///
    /// PROBLEM
    ///     https://leetcode.com/problems/reverse-integer/
    /// 
    /// RESULT
    ///     Runtime: 40 ms, faster than 86.23% of C# online submissions for Reverse Integer.
    /// 
    /// </summary>
    public class Solution
    {
        public int Reverse(int x)
        {
            int.TryParse(string.Concat(x.ToString().Reverse()).TrimEnd('-'), out var output);
            return output * (x < 0 ? -1 : 1);
        }
    }
}
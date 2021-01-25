using System.Linq;

namespace LeetCode.Problems.Medium.StringToInteger
{
    /// <summary>
    ///
    ///  PROBLEM DEFINITION
    ///     https://leetcode.com/problems/string-to-integer-atoi/
    ///
    ///  RESULT
    ///
    /// 
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// Runtime: 72 ms, faster than 93.35% of C# online submissions for String to Integer (atoi).
        /// </summary>
        public int MyAtoi(string s)
        {
            s = s.TrimStart();
            var input = s.TrimStart('-', '+');
            
            // Both negative and positive signs.
            if (s.Length - input.Length > 1) return 0;
            
            var hasNegativeSign = s.StartsWith('-');
            
            var digits = input.TakeWhile(char.IsDigit).ToArray();
            if (digits.Length == 0) return 0;

            var parsed = int.TryParse(new string(digits), out var result);
            if (parsed) return result * (hasNegativeSign ? -1 : 1);;
            
            return hasNegativeSign ? int.MinValue : int.MaxValue;
        }
    }
}
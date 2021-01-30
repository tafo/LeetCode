using System.Collections.Generic;

namespace LeetCode.Problems.Medium.GenerateParantheses
{
    /// <summary>
    /// Problem: https://leetcode.com/problems/generate-parentheses/
    /// </summary>
    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var output = new List<string>();
            
            BackTrack(string.Empty, 0, 0);
            
            return output;

            void BackTrack(string current, int open, int close)
            {
                if (current.Length == 2 * n)
                {
                    output.Add(current);
                    return;
                }

                if (open < n)
                {
                    BackTrack(current + "(", open + 1, close);
                }

                if (close < open)
                {
                    BackTrack(current + ")", open, close + 1);
                }
            }
        }
    }
}
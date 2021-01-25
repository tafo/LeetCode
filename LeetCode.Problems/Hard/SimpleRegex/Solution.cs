namespace LeetCode.Problems.Hard.SimpleRegex
{
    /// <summary>
    /// PROBLEM DEFINITION
    ///     https://leetcode.com/problems/regular-expression-matching/
    /// RESULT
    ///     Runtime: 72 ms, faster than 94.69% of C# online submissions for Regular Expression Matching.
    /// </summary>
    public class Solution
    {
        public enum Result
        {
            None,
            True,
            False
        }

        public bool IsMatch(string s, string p)
        {
            var memo = new Result[s.Length + 1][];
            for (var i = 0; i < memo.Length; i++)
            {
                memo[i] = new Result[p.Length + 1];
            }

            return Dp(0, 0);

            bool Dp(int i, int j)
            {
                if (memo[i][j] != Result.None)
                {
                    return memo[i][j] == Result.True;
                }
                
                bool result;

                if (j == p.Length)
                {
                    result = i == s.Length;
                }
                else
                {
                    var firstMatch = i < s.Length && (s[i] == p[j] || '.' == p[j]);

                    if (j + 1 < p.Length && p[j + 1] == '*')
                    {
                        result = Dp(i, j + 2) || firstMatch && Dp(i + 1, j);
                    }
                    else
                    {
                        result = firstMatch && Dp(i + 1, j + 1);
                    }
                }

                memo[i][j] = result ? Result.True : Result.False;
                
                return result;
            }
        }
    }
}
namespace LeetCode.Problems.Medium.LongestPalindrome
{
    public class Solution
    {
        /// <summary>
        /// PROBLEM
        ///     https://leetcode.com/problems/longest-palindromic-substring/submissions/
        /// RESULT
        ///     Runtime: 96 ms, faster than 82.01% of C# online submissions for Longest Palindromic Substring.
        /// </summary>
        public string LongestPalindrome(string s)
        {
            if (s.Length < 2) return s;
            var output = s.Substring(0, 1);

            var max = 0;
            for (var i = 1; i < s.Length; i++)
            {
                CheckPalindrome(i - 1, i, 0);
                if (i > 1)
                    CheckPalindrome(i - 2, i, 1);
            }

            void CheckPalindrome(int left, int right, int counter)
            {
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    left--;
                    right++;
                    counter += 2;
                }

                if (counter <= max) return;

                output = s.Substring(left + 1, right - left - 1);
                max = counter;
            }

            return output;
        }
    }
}
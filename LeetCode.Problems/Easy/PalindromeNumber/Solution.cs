using System.Linq;

namespace LeetCode.Problems.Easy.PalindromeNumber
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x < 10) return true;
            var number = x.ToString();
            return number == new string(number.Reverse().ToArray());
        }
    }
}
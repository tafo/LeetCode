using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems.Medium.LetterCombinations
{
    /// <summary>
    /// Problem: https://leetcode.com/problems/letter-combinations-of-a-phone-number/
    /// </summary>
    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            var map = new[] { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            return digits
                .Select(digit => map[digit - '2'])
                .Aggregate(Enumerable.Empty<string>(),
                    (combs, next) => combs.DefaultIfEmpty().SelectMany(comb => next, (comb, ch) => $"{comb}{ch}"))
                .ToList();
        }
    }
}
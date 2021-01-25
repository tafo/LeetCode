using System;
using System.Collections.Generic;

namespace LeetCode.Problems.Easy.RomanToInteger
{
    /// <summary>
    ///
    /// Problem >> https://leetcode.com/problems/roman-to-integer/
    ///
    /// Time Complexity >>
    /// Space Complexity >>
    /// 
    /// </summary>
    public class Solution
    {
        public int RomanToInt(string s)
        {
            var romans = new Dictionary<char, int>
            {
                {'I', 1}, 
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000},
            };
            
            var output = 0;
            var previousValue = output = romans[s[^1]];
            for (var i = s.Length - 2; i >= 0; i--)
            {
                var value = romans[s[i]];
                if (previousValue > value)
                {
                    output -= value;
                }
                else
                {
                    output += value;
                }

                previousValue = value;
            }
            
            return output;
        }
    }
}
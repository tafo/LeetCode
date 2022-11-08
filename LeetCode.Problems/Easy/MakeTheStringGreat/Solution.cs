using System;
using System.Collections.Generic;
using System.Linq;


namespace LeetCode.Problems.Easy.MakeTheStringGreat;

/// <summary>
/// https://leetcode.com/problems/make-the-string-great/description/
/// </summary>
public class Solution
{
    public string MakeGood(string s)
    {
        var characters = new Stack<char>();
        characters.Push(s[0]);
        for (var i = 1; i < s.Length; i++)
        {
            if (characters.Count > 0 && 32 == Math.Abs(characters.Peek() - s[i]))
            {
                characters.Pop();
            }
            else
            {
                characters.Push(s[i]);
            }
        }

        return string.Concat(characters.Reverse());
    }
}
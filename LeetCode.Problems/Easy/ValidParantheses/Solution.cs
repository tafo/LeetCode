using System.Collections.Generic;

namespace LeetCode.Problems.Easy.ValidParantheses
{
    /// <summary>
    /// Problem: https://leetcode.com/problems/valid-parentheses/
    /// </summary>
    public class Solution
    {
        public bool IsValid(string s)
        {
            var charStack = new Stack<char>();
            foreach (var c in s)
            {
                switch (c)
                {
                    case '(':
                        charStack.Push(')');
                        break;
                    case '[':
                        charStack.Push(']');
                        break;
                    case '{':
                        charStack.Push('}');
                        break;
                    default:
                    {
                        if (charStack.Count == 0 || charStack.Pop() != c) return false;
                        break;
                    }
                }
            }

            return charStack.Count == 0;
        }
    }
}
using System;

namespace LeetCode.Problems.Easy.IsIsomorphic
{
    public class SolutionBest
    {
        public bool IsIsomorphic(string s, string t)
        {
            var map = new char[256];
            for (var i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (map[ch] == default(char))
                {
                    if (Array.IndexOf(map, t[i]) >= 0)
                    {
                        return false;
                    }

                    map[ch] = t[i];
                }
                else
                {
                    if (map[ch] != t[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

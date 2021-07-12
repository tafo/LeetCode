using System.Collections.Generic;

namespace LeetCode.Problems.Easy.IsIsomorphic
{
    public class SolutionLibero
    {
        public bool IsIsomorphic(string s, string t)
        {
            var set = new SortedSet<char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (set.Contains(s[i])) continue;
                var leftIndex = i;
                var rightIndex = i;
                while (leftIndex >= 0)
                {
                    leftIndex= s.IndexOf(s[i], leftIndex + 1);
                    rightIndex = t.IndexOf(t[i], rightIndex + 1);
                    if (leftIndex != rightIndex) return false;
                }
                set.Add(s[i]);
            }

            return true;
        }
    }
}

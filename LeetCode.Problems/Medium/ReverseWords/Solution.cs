using System.Linq;

namespace LeetCode.Problems.Medium.ReverseWords;

public class Solution
{
    public string ReverseWords(string s)
    {
        return string.Join(' ', s.Split(' ').Where(x => x != string.Empty).Reverse());
    }
}
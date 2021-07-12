using System.Collections.Generic;

namespace LeetCode.Problems.Common
{
public static class StringExtensions
{
    public static IList<int> FindAll(this string input, char ch)
    {
        var result = new List<int>();
        for (var i = 0; i < input.Length; i++)
        {
            if(input[i] == ch) result.Add(i);
        }
        return result;
    }
}
}

namespace LeetCode.Problems.Easy.StrStr
{
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle == string.Empty) return 0;
            if (needle.Length > haystack.Length) return -1;

            var i = 0;
            var j = 0;
            while (i < haystack.Length && j < needle.Length)
            {
                if (haystack[i++] == needle[j])
                {
                    j++;
                }
                else
                {
                    i -= j;
                    j = 0;
                }
            }

            return j == needle.Length ? i - j : -1;
        }
    }
}
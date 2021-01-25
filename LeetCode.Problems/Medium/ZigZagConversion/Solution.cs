using System.Text;

namespace LeetCode.Problems.Medium.ZigZagConversion
{
    /// <summary>
    ///
    /// https://leetcode.com/problems/zigzag-conversion/
    /// 
    /// Runtime: 88 ms, faster than 96.50% of C# online submissions for ZigZag Conversion.
    /// 
    /// </summary>
    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;
            var sb = new StringBuilder();
            var totalIncrement = (numRows - 1) * 2;
            var incrementPair = new int[2];
            for (var i = 0; i < numRows; i++)
            {
                var zigZag = true;
                incrementPair[0] = totalIncrement - i * 2;
                incrementPair[1] = i * 2;
                var index = i;
                
                while (index < s.Length)
                {
                    sb.Append(s[index]);
                    if (zigZag)
                    {
                        index += incrementPair[0] == 0 ? incrementPair[1] : incrementPair[0];
                    }
                    else
                    {
                        index += incrementPair[1] == 0 ? incrementPair[0] : incrementPair[1];
                    }

                    zigZag = !zigZag;
                }
            }

            return sb.ToString();
        }
    }
}
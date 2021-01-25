using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace LeetCode.Problems.Medium.LengthOfLongestSubstring
{
    public class Test
    {
        [Theory]
        [MemberData(nameof(InputAndOutput))]
        public void Check(string s, int expectedOutput)
        {
            var solution = new Solution();
            solution.LengthOfLongestSubstring(s).Should().Be(expectedOutput);
        }

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public static IEnumerable<object[]> InputAndOutput()
        {
            return new List<object[]>
            {
                new object[]{"", 0},
                new object[]{" ", 1},
                new object[]{"au", 2},
                new object[]{"aab", 2},
                new object[]{"abba", 2},
                new object[]{"dvdf", 3},
                new object[]{"bbbbb", 1},
                new object[]{"pwwkew", 3},
                new object[]{"abcabcbb", 3},
            };
        }
    }
}
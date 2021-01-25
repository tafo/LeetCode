using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.LongestPalindrome
{
    public class Test
    {
        private readonly ITestOutputHelper _outputHelper;

        public Test(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Theory]
        [MemberData(nameof(InputAndOutput))]
        public void Check(string s, List<string> expectedOutputs)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            var palindrome = solution.LongestPalindrome(s);
            expectedOutputs.Should().Contain(palindrome);
            timer.Stop();
            _outputHelper.WriteLine($"{timer.ElapsedTicks}");
        }

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public static IEnumerable<object[]> InputAndOutput()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(
                "whdqcudjpisufnrtsyupwtnnbsvfptrcgvwfdfwobbjglmpynebblpigaflpbezjvjgbmofejyjssdhbgghgrhzuplbeptp");
            return new List<object[]>
            {
                new object[] {"", new List<string>{""}},
                new object[] {"a", new List<string>{"a"}},
                new object[] {"ab", new List<string> {"a", "b"}},
                new object[] {"bb", new List<string> {"bb"}},
                new object[] {"abb", new List<string> {"bb"}},
                new object[] {"abc", new List<string> {"a", "b", "c"}},
                new object[] {"cbbd", new List<string> {"bb"}},
                new object[] {"babad", new List<string> {"aba", "bab"}},
                new object[] {"dabad", new List<string> {"dabad"}},
                new object[] {"xdabad", new List<string> {"dabad"}},
                new object[] {"xdabady", new List<string> {"dabad"}},
                new object[] {stringBuilder.ToString(), new List<string> {"wfdfw"}},
            };
        }
    }
}
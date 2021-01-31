using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Hard.SubstringWithConcatOfAllWords
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
        public void Check(string s, string[] words, IList<int> expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.FindSubstring(s, words);
            timer.Stop();
            actualOutput.Should().BeEquivalentTo(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                "barfoothefoobarman",
                new List<string> { "foo", "bar" },
                new List<int> {0, 9}
            },
            new object[]
            {
                "barfoofoobarthefoobarman",
                new List<string> { "bar", "foo", "the" },
                new List<int> {6, 9, 12}
            },
            new object[]
            {
                "wordgoodgoodgoodbestword",
                new List<string> { "word","good","best","good" },
                new List<int> {8}
            },
            new object[]
            {
                "wordgoodthegoodgoodbestword",
                new List<string> { "word","good","best","good" },
                new List<int> {11}
            },
            new object[]
            {
                "lingmindraboofooowingdingbarrwingmonkeypoundcake",
                new List<string> { "fooo","barr","wing","ding","wing" },
                new List<int> {13}
            },
            new object[]
            {
                "ababababab",
                new List<string> { "ababa","babab" },
                new List<int> {0}
            },
            new object[]
            {
                "ababaab",
                new List<string> { "ab","ba", "ba" },
                new List<int> {1}
            },
        };
    }
}
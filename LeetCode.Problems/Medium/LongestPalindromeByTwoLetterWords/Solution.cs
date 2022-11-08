using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.LongestPalindromeByTwoLetterWords;

/// <summary>
/// https://leetcode.com/problems/longest-palindrome-by-concatenating-two-letter-words/
/// Put pairs to left and right of middle index to create a better solution. 
/// </summary>
public class Solution
{
    public int LongestPalindrome(string[] words)
    {
        string test = string.Empty;
        var numberOfPairs = 0;
        var elementDictionary = new Dictionary<string, Element>();
        foreach (var word in words)
        {
            var reversedWord = string.Concat(word.Reverse());
            if (elementDictionary.ContainsKey(reversedWord))
            {
                var element = elementDictionary[reversedWord];
                if (element.Counter > 0)
                {
                    numberOfPairs++;
                    test = test + word + reversedWord;
                    element.Counter--;
                }
                else if(elementDictionary.ContainsKey(word))
                {
                    element = elementDictionary[word];
                    element.Counter++;
                }
                else
                {
                    elementDictionary.Add(word, new Element {IsDouble = word[0] == word[1], Counter = 1});    
                }
            }
            else if (elementDictionary.ContainsKey(word))
            {
                var element = elementDictionary[word];
                element.Counter++;
            }
            else
            {
                elementDictionary.Add(word, new Element {IsDouble = word[0] == word[1], Counter = 1});
            }
        }
        var hasDouble = elementDictionary.Values.Any(x => x.IsDouble && x.Counter == 1);
        return numberOfPairs * 4 + (hasDouble ? 2 : 0);
    }
}

public class Element
{
    public int Counter { get; set; }
    public bool IsDouble { get; set; }
}

public class Test
{
    private readonly ITestOutputHelper _outputHelper;

    public Test(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory]
    [MemberData(nameof(InputAndOutput))]
    public void Check(string[] words, int expectedOutput)
    {
        var solution = new Solution();
        var timer = Stopwatch.StartNew();
        var actualOutput = solution.LongestPalindrome(words);
        timer.Stop();
        actualOutput.Should().Be(expectedOutput);
        _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
    }

    public static IEnumerable<object[]> InputAndOutput => new List<object[]>
    {
        new object[] { new[] { "ab", "ty", "yt", "lc", "cl", "ab" }, 8 },
        new object[] { new[] { "dd","aa","bb","dd","aa","dd","bb","dd","aa","cc","bb","cc","dd","cc" }, 22 },
        new object[] { new[] { "cc", "ll", "xx" }, 2 },
        new object[] { new[] { "lc", "cl", "gg" }, 6 },
        new object[] { new[] { "mm","mm","yb","by","bb","bm","ym","mb","yb","by","mb","mb","bb","yb","by","bb","yb","my","mb","ym" }, 30 },
        new object[] { new[] { "qw","rr","ll","vv","iw","wq","cc","wi","jj","iw","pp","iw","mm","ss","bb","oo","wi","dd","wq","ff","qi","qw","qi","qi","zz","wq","iw","wi","qq","qw","wi","hh","qi","pp","vv","wi","wq","wi","wi","wi","iw","qi","bb","qw","qi","rr" }, 54 },
    };
}
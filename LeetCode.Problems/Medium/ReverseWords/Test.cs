using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.ReverseWords;

public class Test
{
    private readonly ITestOutputHelper _outputHelper;

    public Test(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory]
    [MemberData(nameof(InputAndOutput))]
    public void Check(string input, string expectedOutput)
    {
        var solution = new Solution();
        var timer = Stopwatch.StartNew();
        var actualOutput = solution.ReverseWords(input);
        timer.Stop();
        actualOutput.Should().Be(expectedOutput);
        _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
    }

    public static IEnumerable<object[]> InputAndOutput => new List<object[]>
    {
        new object[] {"the sky is blue", "blue is sky the"},
        new object[] {"  hello world  ", "world hello"},
        new object[] {"a good   example", "example good a"
        },
    };
}
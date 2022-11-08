using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.MinimumGeneticMutation;

public class Test
{
    private readonly ITestOutputHelper _outputHelper;

    public Test(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory]
    [MemberData(nameof(InputAndOutput))]
    public void Check(string start, string end, string[] bank, int expectedOutput)
    {
        var solution = new OptimizedSolution();
        var timer = Stopwatch.StartNew();
        var actualOutput = solution.MinMutation(start, end, bank);
        timer.Stop();
        actualOutput.Should().Be(expectedOutput);
        _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
    }

    public static IEnumerable<object[]> InputAndOutput => new List<object[]>
    {
        new object[] { "AACCGGTT", "AACCGGTA", new[] { "AACCGGTA" }, 1 },
        new object[] { "AACCTTGG", "AATTCCGG", new[] { "AATTCCGG", "AACCTGGG", "AACCCCGG", "AACCTACC" }, -1 },
        new object[] { "AACCGGTT", "AAACGGTA", new[] { "AACCGGTA", "AACCGCTA", "AAACGGTA" }, 2 },
        new object[] { "AACCGGTT", "AAACGGTA", new[] { "AACCGATT", "AACCGATA", "AAACGATA", "AAACGGTA" }, 4}
    };
}
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.WhereWillTheBallFall;

public class Test
{
    private readonly ITestOutputHelper _outputHelper;

    public Test(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Theory]
    [MemberData(nameof(InputAndOutput))]
    public void Check(int[][] input, int[] output)
    {
        var timer = Stopwatch.StartNew();
        timer.Start();
        var solution = new Solution();
        var result = solution.FindBall(input);
        timer.Stop();
        result.SequenceEqual(output).Should().BeTrue();
        _outputHelper.WriteLine($"{timer.ElapsedTicks}");
    }

    public static IEnumerable<object[]> InputAndOutput()
    {
        return new List<object[]>
        {
            new object[]
            {
                new[]
                {
                    new[] { 1, 1, 1, -1, -1 },
                    new[] { 1, 1, 1, -1, -1 },
                    new[] { -1, -1, -1, 1, 1 },
                    new[] { 1, 1, 1, 1, -1 },
                    new[] { -1, -1, -1, -1, -1 }
                },
                new[] { 1, -1, -1, -1, -1 }
            },
            new object[]
            {
                new[]
                {
                    new[] { 1, 1, 1, 1, 1, 1 },
                    new[] { -1, -1, -1, -1, -1, -1 },
                    new[] { 1, 1, 1, 1, 1, 1 },
                    new[] { -1, -1, -1, -1, -1, -1 },
                },
                new[] { 0, 1, 2, 3, 4, -1 }
            }
        };
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode.Problems.Medium.MinimumGeneticMutation;

/// <summary>
/// https://leetcode.com/problems/minimum-genetic-mutation/
/// Not Optimized
/// </summary>
public class Solution
{
    public int MinMutation(string start, string end, string[] bank)
    {
        var resultList = new List<int>();
        CheckChain(start, 0, new List<string>(bank));
        return resultList.Count == 0 ? -1 : resultList.Min();

        void CheckChain(string gene, int mutation, List<string> geneBank)
        {
            if (gene == end && mutation > 0)
            {
                resultList.Add(mutation);
                return;
            }
            foreach (var validGene in geneBank)
            {
                var counter = 0;
                for (var i = 0; i < 8; i++)
                {
                    if (gene[i] != validGene[i])
                    {
                        counter++;
                    }

                    if (counter == 2)
                    {
                        break;
                    }
                }

                if (counter == 1)
                {
                    CheckChain(validGene, mutation + 1, geneBank.Where(x => x != validGene).ToList());
                }
            }
        }
    }
}

public class OptimizedSolution
{
    public int MinMutation(string start, string end, string[] bank)
    {
        var visited = new bool[bank.Length];
        var resultList = new List<int>();
        CheckChain(start, 0);
        return resultList.Count == 0 ? -1 : resultList.Min();

        void CheckChain(string gene, int mutation)
        {
            if (gene == end && mutation > 0)
            {
                resultList.Add(mutation);
                return;
            }

            for (var index = 0; index < bank.Length; index++)
            {
                if(visited[index]) continue;
                var validGene = bank[index];
                visited[index] = true;
                var counter = 0;
                for (var i = 0; i < 8; i++)
                {
                    if (gene[i] != validGene[i])
                    {
                        counter++;
                    }

                    if (counter == 2)
                    {
                        break;
                    }
                }

                if (counter == 1)
                {
                    CheckChain(validGene, mutation + 1);
                }

                visited[index] = false;
            }
        }
    }
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
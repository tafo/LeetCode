using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
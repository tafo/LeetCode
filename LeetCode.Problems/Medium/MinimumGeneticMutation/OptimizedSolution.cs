using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems.Medium.MinimumGeneticMutation;

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
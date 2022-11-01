namespace LeetCode.Problems.Easy.ToeplitzMatrix;

public class Solution
{
    public bool IsToeplitzMatrix(int[][] matrix)
    {
        var visited = new bool[matrix.Length][];
        for (var i = 0; i < matrix.Length - 1; i++)
        {
            visited[i] = new bool[matrix[i].Length];
            for (var j = 0; j < matrix[i].Length - 1; j++)
            {
                if(visited[i][j]) continue;
                if (matrix[i][j] != matrix[i + 1][j + 1])
                {
                    return false;
                }

                visited[i][j] = true;
            }
        }

        return true;
    }
}
using System.Linq;
using LeetCode.Problems.Common;

namespace LeetCode.Problems.Medium.WhereWillTheBallFall;

/// <summary>
/// https://leetcode.com/problems/where-will-the-ball-fall/
/// </summary>
public class Solution
{
    public int[] FindBall(int[][] grid)
    {
        var rowSize = grid.Length;
        var columnSize = grid[0].Length;
        var balls = new Ball[columnSize];
        for (var i = 0; i < columnSize; i++)
        {
            balls[i] = new Ball { RowIndex = 0, ColumnIndex = i, CurrentDirection = Direction.Down };
        }

        foreach (var ball in balls)
        {
            while (ball.ColumnIndex != -1 && ball.RowIndex < rowSize)
            {
                var cellValue = grid[ball.RowIndex][ball.ColumnIndex];
                switch (ball.CurrentDirection)
                {
                    case Direction.Down:
                        switch (cellValue)
                        {
                            case 1:
                                ball.CurrentDirection = Direction.Right;
                                ball.ColumnIndex++;
                                break;
                            case -1:
                                ball.CurrentDirection = Direction.Left;
                                ball.ColumnIndex--;
                                break;
                        }

                        break;
                    case Direction.Left:
                        switch (cellValue)
                        {
                            case 1:
                                ball.ColumnIndex = -1;
                                break;
                            case -1:
                                ball.CurrentDirection = Direction.Down;
                                ball.RowIndex++;
                                break;
                        }

                        break;
                    case Direction.Right:
                    default:
                        switch (cellValue)
                        {
                            case 1:
                                ball.CurrentDirection = Direction.Down;
                                ball.RowIndex++;
                                break;
                            case -1:
                                ball.ColumnIndex = -1;
                                break;
                        }

                        break;
                }

                if (ball.ColumnIndex == columnSize) ball.ColumnIndex = -1;
            }
        }

        return balls.Select(x => x.ColumnIndex).ToArray();
    }

    private enum Direction
    {
        Down = 0,
        Left = -1,
        Right = 1
    }

    private class Ball
    {
        public Direction CurrentDirection { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
    }
}

// If CurrentDirection is Right, it can not be Left in the following cell
// If CurrentDirection is Left, it can not be Right in the following cell
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace LeetCode.Problems.Medium.WordSearch;

/// <summary>
/// https://leetcode.com/problems/word-search/
/// </summary>
///
public class Cell
{
    public char Letter;
    public readonly List<Cell> NextLetterList = new();
    public bool IsVisited;
}

public class Solution
{
    private int _rowSize;
    private int _columnSize;

    public bool Exist(char[][] board, string word)
    {
        _rowSize = board.Length;
        _columnSize = board[0].Length;
        bool isFound = false;
        var cellList = new Cell[_rowSize, _columnSize];
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                var cell = cellList[i, j] ??= new Cell
                {
                    Letter = board[i][j]
                };
                AddNextCell(i - 1, j, cell);
                AddNextCell(i + 1, j, cell);
                AddNextCell(i, j - 1, cell);
                AddNextCell(i, j + 1, cell);
            }
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] != word[0])
                {
                    continue;
                }

                cellList[i, j].IsVisited = true;
                Chain(1, cellList[i, j]);
                cellList[i, j].IsVisited = false;
                
                if (isFound)
                {
                    return true;
                }
            }
        }
        
        return false;

        void AddNextCell(int rowIndex, int colIndex, Cell parentCell)
        {
            if (
                rowIndex < 0 ||
                rowIndex == _rowSize ||
                colIndex < 0 ||
                colIndex == _columnSize
            )
            {
                return;
            }

            Cell cell;
            if (cellList[rowIndex, colIndex] == null)
            {
                cell = cellList[rowIndex, colIndex] = new Cell
                {
                    Letter = board[rowIndex][colIndex]
                };
            }
            else
            {
                cell = cellList[rowIndex, colIndex];
            }
            
            parentCell.NextLetterList.Add(cell);
        }

        void Chain(int letterIndex, Cell parentCell)
        {
            if (letterIndex == word.Length)
            {
                isFound = true;
                return;
            }

            foreach (var cell in parentCell.NextLetterList)
            {
                if (cell.Letter != word[letterIndex] || cell.IsVisited)
                {
                    continue;
                }

                cell.IsVisited = true;
                Chain(letterIndex + 1, cell);
                if (isFound) return;
                cell.IsVisited = false;
            }
        }
    }
}


[SuppressMessage("ReSharper", "StringLiteralTypo")]
public class Test
{
    [Theory]
    [MemberData(nameof(InputAndOutput))]
    public void Check(char[][] board, string word, bool expectedResult)
    {
        var solution = new Solution();
        var actualResult = solution.Exist(board, word);

        actualResult.Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> InputAndOutput => new List<object[]>
    {
        new object[]
        {
            new[]
            {
                new[] { 'A', 'B', 'C', 'E' },
                new[] { 'S', 'F', 'C', 'S' },
                new[] { 'A', 'D', 'E', 'E' }
            },
            "ABCCED",
            true
        },
        new object[]
        {
            new[]
            {
                new[] { 'A', 'B', 'C', 'E' },
                new[] { 'S', 'F', 'C', 'S' },
                new[] { 'A', 'D', 'E', 'E' }
            },
            "ABCB",
            false
        },
        new object[]
        {
            new[]
            {
                new[] { 'A', 'A' },
                new[] { 'A', 'A' },
                new[] { 'A', 'B' }
            },
            "AAAAAB",
            true
        },
        new object[]
        {
            new[]
            {
                new[] { 'A', 'A' },
                new[] { 'A', 'A' },
            },
            "AA",
            true
        },
        new object[]
        {
            new[]
            {
                new[] { 'A', 'A' },
            },
            "AAA",
            false
        },
        new object[]
        {
            new[]
            {
                new[] { 'A', 'B' },
                new[] { 'C', 'D' },
            },
            "ABCD",
            false
        },
        new object[]
        {
            new[]
            {
                new[] { 'A', 'A', 'A' },
                new[] { 'A', 'A', 'A' },
                new[] { 'A', 'A', 'B' }
            },
            "AAAAAAAAB",
            true
        },
    };
}
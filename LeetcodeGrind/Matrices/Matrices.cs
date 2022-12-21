using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Matrices;

public class Matrices
{
    // 48. Rotate Image
    public void Rotate(int[][] matrix)
    {
        if (matrix.Length == 1) { return; }

        var offset = 0;
        var first = 0;
        var last = matrix.Length - 1;

        while (first < last)
        {
            while (first + offset < last)
            {
                var temp = matrix[first][first + offset];
                matrix[first][first + offset] = matrix[last - offset][first];
                matrix[last - offset][first] = matrix[last][last - offset];
                matrix[last][last - offset] = matrix[first + offset][last];
                matrix[first + offset][last] = temp;

                offset++;
            }
            offset = 0;
            first++;
            last--;
        }
    }


    // 54. Spiral Matrix
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var spiral = new List<int>();
        var firstRow = 0;
        var firstCol = 0;
        var lastRow = matrix.Length - 1;
        var lastCol = matrix[0].Length - 1;

        while (firstRow < lastRow && firstCol < lastCol)
        {
            // top row
            for (int c = firstCol; c <= lastCol; c++)
            {
                spiral.Add(matrix[firstRow][c]);
            }

            // right column
            for (int r = firstRow + 1; r < lastRow; r++)
            {
                spiral.Add(matrix[r][lastCol]);
            }

            // bottom row
            for (int c = lastCol; c >= firstCol; c--)
            {
                spiral.Add(matrix[lastRow][c]);
            }

            // left column
            for (int r = lastRow - 1; r > firstRow; r--)
            {
                spiral.Add(matrix[r][firstCol]);
            }

            firstRow++;
            lastRow--;
            firstCol++;
            lastCol--;

            if (firstRow == lastRow || firstCol == lastCol) { break; }
        }

        if (firstRow == lastRow && firstCol == lastCol)
        {
            spiral.Add(matrix[firstRow][firstCol]);
        }
        else if (firstRow == lastRow)
        {
            for (int c = firstCol; c <= lastCol; c++)
                spiral.Add(matrix[firstRow][c]);
        }
        else if (firstCol == lastCol)
        {
            for (int r = firstRow; r <= lastRow; r++)
                spiral.Add(matrix[r][firstCol]);
        }

        return spiral;
    }


    // 289. Game of Life
    public void GameOfLife(int[][] board)
    {
        var state = new int[board.Length][];
        for (int i = 0; i < board.Length; i++)
        {
            state[i] = new int[board[i].Length];
        }
        var lastRow = board.Length - 1;
        var lastCol = board[0].Length - 1;

        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                var upLeft = r > 0 && c > 0 ? board[r - 1][c - 1] : 0;
                var up = r > 0 ? board[r - 1][c] : 0;
                var upRight = r > 0 && c < lastCol ? board[r - 1][c + 1] : 0;
                var left = c > 0 ? board[r][c - 1] : 0;
                var right = c < lastCol ? board[r][c + 1] : 0;
                var downLeft = r < lastRow && c > 0 ? board[r + 1][c - 1] : 0;
                var down = r < lastRow ? board[r + 1][c] : 0;
                var downRight = r < lastRow && c < lastCol ? board[r + 1][c + 1] : 0;

                var neighbors = upLeft + up + upRight 
                              + left + right
                              + downLeft + down + downRight;

                if (neighbors < 2)
                    state[r][c] = 0;
                else if (neighbors == 2)
                    state[r][c] = board[r][c] & 1;
                else if (neighbors == 3)
                    state[r][c] = 1;
                else // neighbors >= 4
                    state[r][c] = 0;
            }
        }

        for (int i = 0; i < state.Length; i++)
        {
            state[i].CopyTo(board[i], 0);
        }
    }


    // 2373. Largest Local Values in a Matrix
    public int[][] LargestLocal(int[][] grid)
    {
        var ans = new int[grid.Length - 2][];
        for (int i = 0; i < ans.Length; i++)
            ans[i] = new int[ans.Length];

        for (int r = 1; r < grid.Length - 1; r++)
        {
            for (int c = 1; c < grid[r].Length - 1; c++)
            {
                var max = int.MinValue;
                for (int i = r - 1; i <= r + 1; i++)
                {
                    for (int j = c - 1; j <= c + 1; j++)
                    {
                        if (grid[i][j] > max)
                            max = grid[i][j];
                    }
                }
                ans[r-1][c-1] = max;
            }
        }

        return ans;
    }
}

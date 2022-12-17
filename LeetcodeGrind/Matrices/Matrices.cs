using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Matrices;

public class Matrices
{
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

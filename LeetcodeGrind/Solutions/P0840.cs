namespace LeetcodeGrind.Solutions;

// 840. Magic Squares In Grid
public class P0840
{
    public int NumMagicSquaresInside(int[][] grid)
    {
        if (grid.Length < 3 || grid[0].Length < 3)
        {
            return 0;
        }

        var count = 0;
        for (int i = 0; i < grid.Length - 2; i++)
        {
            for (int j = 0; j < grid[0].Length - 2; j++)
            {
                if (IsMagic(grid, i, j))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private bool IsMagic(int[][] grid, int r, int c)
    {
        // Check for distinct numbers from 1 to 9
        var hs = new HashSet<int>(9);
        for (int i = r; i < r + 3; i++)
        {
            for (int j = c; j < c + 3; j++)
            {
                if (grid[i][j] < 1 || grid[i][j] > 9)
                {
                    return false;
                }
                hs.Add(grid[i][j]);
            }
        }
        if (hs.Count != 9)
        {
            return false;
        }

        int sum = grid[r][c] + grid[r][c + 1] + grid[r][c + 2];

        // Check row and column sums
        for (int i = 0; i < 3; ++i)
        {
            if (grid[r + i][c] + grid[r + i][c + 1] + grid[r + i][c + 2] != sum ||
                grid[r][c + i] + grid[r + 1][c + i] + grid[r + 2][c + i] != sum)
            {
                return false;
            }
        }

        // Check diagonals sums
        if (grid[r][c] + grid[r + 1][c + 1] + grid[r + 2][c + 2] != sum ||
            grid[r][c + 2] + grid[r + 1][c + 1] + grid[r + 2][c] != sum)
        {
            return false;
        }

        return true;
    }
}

namespace LeetcodeGrind.Solutions;

// 463. Island Perimeter
public class P0463
{
    public int IslandPerimeter(int[][] grid)
    {
        var count = 0;

        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[r].Length; c++)
            {
                if (grid[r][c] == 0)
                    continue;

                if (r == 0 || (r > 0 && grid[r - 1][c] == 0))
                    count++;

                if (r == grid.Length - 1 ||
                    (r < grid.Length - 1 && grid[r + 1][c] == 0))
                    count++;

                if (c == 0 || (c > 0 && grid[r][c - 1] == 0))
                    count++;

                if (c == grid[r].Length - 1 ||
                    (c < grid[r].Length - 1 && grid[r][c + 1] == 0))
                    count++;
            }
        }

        return count;
    }
}

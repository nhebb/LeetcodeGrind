namespace LeetcodeGrind.Solutions;

// 3142. Check if Grid Satisfies Conditions
public class P3142
{
    public bool SatisfiesConditions(int[][] grid)
    {
        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[0].Length; c++)
            {
                if ((r + 1 < grid.Length && grid[r][c] != grid[r + 1][c]) ||
                    (c + 1 < grid[0].Length && grid[r][c] == grid[r][c + 1]))
                {
                    return false;
                }

            }
        }

        return true;
    }
}

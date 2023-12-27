namespace LeetcodeGrind.Solutions;

// 2639. Find the Width of Columns of a Grid
public class P2639
{
    public int[] FindColumnWidth(int[][] grid)
    {
        var ans = new int[grid[0].Length];

        for (int c = 0; c < grid[0].Length; c++)
        {
            var max = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                max = Math.Max(max, grid[r][c].ToString().Length);
            }
            ans[c] = max;
        }

        return ans;
    }
}

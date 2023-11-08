namespace LeetcodeGrind.Solutions;

// 2500. Delete Greatest Value in Each Row
public class P2500
{
    public int DeleteGreatestValue(int[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            Array.Sort(grid[i]);
        }

        var ans = 0;

        for (int j = grid[0].Length - 1; j >= 0; j--)
        {
            int max = int.MinValue;
            for (int i = 0; i < grid.Length; i++)
            {
                max = Math.Max(max, grid[i][j]);
            }
            ans += max;
        }

        return ans;
    }
}

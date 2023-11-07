namespace LeetcodeGrind.Solutions;

// 2373. Largest Local Values in a Matrix
public class P2373
{
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
                ans[r - 1][c - 1] = max;
            }
        }

        return ans;
    }
}

namespace LeetcodeGrind.Solutions;

// 2017. Grid Game
public class P2017
{
    public long GridGame(int[][] grid)
    {
        var pre = new long[grid[0].Length];
        pre[0] = grid[0][0];
        for (int c = 1; c < grid[0].Length; c++)
            pre[c] = pre[c - 1] + grid[0][c];

        var post = new long[grid[0].Length];
        post[^1] = grid[1][^1];
        for (int c = grid[1].Length - 2; c >= 0; c--)
            post[c] = post[c + 1] + grid[1][c];

        long min = long.MaxValue;
        var i = 0;
        while (i < grid[0].Length)
        {
            min = Math.Min(min,
                Math.Max(pre[^1] - pre[i], post[0] - post[i]));
            i++;
        }

        return min;
    }
}

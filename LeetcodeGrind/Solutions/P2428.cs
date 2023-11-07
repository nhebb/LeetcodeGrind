namespace LeetcodeGrind.Solutions;

// 2428. Maximum Sum of an Hourglass
public class P2428
{
    public int MaxSum(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var max = 0;

        for (int r = 0; r <= rows - 3; r++)
        {
            for (int c = 0; c <= cols - 3; c++)
            {
                var sum = grid[r][c] + grid[r][c + 1] + grid[r][c + 2] +
                                       grid[r + 1][c + 1] +
                          grid[r + 2][c] + grid[r + 2][c + 1] + grid[r + 2][c + 2];

                max = Math.Max(max, sum);
            }
        }

        return max;
    }
}

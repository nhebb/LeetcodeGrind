namespace LeetcodeGrind.Solutions;

// 3195. Find the Minimum Area to Cover All Ones I
public class P3195
{
    public int MinimumArea(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var minR = rows;
        var maxR = 0;
        var minC = cols;
        var maxC = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 1)
                {
                    minR = Math.Min(minR, r);
                    maxR = Math.Max(maxR, r);

                    minC = Math.Min(minC, c);
                    maxC = Math.Max(maxC, c);
                }
            }
        }

        var area = (maxR - minR + 1) * (maxC - minC + 1);

        return area;
    }
}

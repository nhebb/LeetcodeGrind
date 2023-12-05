namespace LeetcodeGrind.Solutions;

// 892. Surface Area of 3D Shapes
public class P0892
{
    public int SurfaceArea(int[][] grid)
    {
        var area = 0;

        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[r].Length; c++)
            {
                if (grid[r][c] == 0)
                    continue;

                var curHeight = grid[r][c];

                var heightUp = r == 0
                    ? curHeight
                    : Math.Max(0, curHeight - grid[r - 1][c]);

                var heightDown = r == grid.Length - 1
                    ? curHeight
                    : Math.Max(0, curHeight - grid[r + 1][c]);

                var heightLeft = c == 0
                    ? curHeight
                    : Math.Max(0, curHeight - grid[r][c - 1]);

                var heightRight = c == grid[r].Length - 1
                    ? curHeight
                    : Math.Max(0, curHeight - grid[r][c + 1]);

                // + 2 for top and bottom
                area += heightUp + heightDown + heightLeft + heightRight + 2;
            }
        }

        return area;
    }
}

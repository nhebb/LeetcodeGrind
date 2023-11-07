namespace LeetcodeGrind.Solutions;

// 695. Max Area of Island
public class P0695
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        if (grid == null)
            return 0;

        int maxArea = 0;

        int IslandDFS(int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length ||
                j < 0 || j >= grid[i].Length ||
                grid[i][j] == 0)
                return 0;

            grid[i][j] = 0;

            return 1 + IslandDFS(grid, i + 1, j)
                     + IslandDFS(grid, i - 1, j)
                     + IslandDFS(grid, i, j + 1)
                     + IslandDFS(grid, i, j - 1);
        }

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    var area = IslandDFS(grid, i, j);
                    maxArea = Math.Max(maxArea, area);
                }
            }
        }

        return maxArea;
    }
}

namespace LeetcodeGrind.Solutions;

// 200. Number of Islands
public class P0200
{
    public int NumIslands(char[][] grid)
    {
        int count = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    count++;
                    IslandsBFS(grid, i, j);
                }
            }
        }
        return count;
    }

    private void IslandsBFS(char[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length ||
            j < 0 || j >= grid[i].Length ||
            grid[i][j] == '0')
            return;

        grid[i][j] = '0';
        IslandsBFS(grid, i + 1, j);
        IslandsBFS(grid, i - 1, j);
        IslandsBFS(grid, i, j + 1);
        IslandsBFS(grid, i, j - 1);
    }
}

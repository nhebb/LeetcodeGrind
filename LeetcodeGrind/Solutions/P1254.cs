namespace LeetcodeGrind.Solutions;

// 1254. Number of Closed Islands
public class P1254
{
    public int ClosedIsland(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var visited = new bool[rows][];
        for (int r = 0; r < rows; r++)
        {
            visited[r] = new bool[cols];
        }

        bool Dfs(int r, int c)
        {
            if (r < 0 || r == rows)
                return false;
            if (c < 0 || c == cols)
                return false;

            if (visited[r][c])
            {
                if (r == 0 || r == rows - 1 || c == 0 | c == cols - 1)
                    return false;
                else
                    return true;
            }

            if (grid[r][c] == 1)
                return true;

            visited[r][c] = true;

            var left = Dfs(r, c - 1);
            var right = Dfs(r, c + 1);
            var top = Dfs(r - 1, c);
            var bottom = Dfs(r + 1, c);

            return left && right && top && bottom;
        }

        var count = 0;
        for (int r = 1; r < rows - 1; r++)
        {
            for (int c = 1; c < cols - 1; c++)
            {
                if (grid[r][c] == 0 && !visited[r][c])
                {
                    if (Dfs(r, c))
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
}

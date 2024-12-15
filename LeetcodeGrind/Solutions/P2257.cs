namespace LeetcodeGrind.Solutions;

// 2257. Count Unguarded Cells in the Grid
public class P2257
{
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        var grid = new int[m][];
        for (int i = 0; i < m; i++)
        {
            grid[i] = new int[n];
        }
        for (int i = 0; i < guards.Length; i++)
        {
            var r = guards[i][0];
            var c = guards[i][1];
            grid[r][c] = -1;
        }
        for (int i = 0; i < walls.Length; i++)
        {
            var r = walls[i][0];
            var c = walls[i][1];
            grid[r][c] = -1;
        }

        void IterateRows(int r, int c, int delta)
        {
            if (r < 0 || r >= m || grid[r][c] == -1)
                return;
            grid[r][c] = 1;
            IterateRows(r + delta, c, delta);
        }
        void IterateCols(int r, int c, int delta)
        {
            if (c < 0 || c >= n || grid[r][c] == -1)
                return;
            grid[r][c] = 1;
            IterateCols(r, c + delta, delta);
        }

        for (int i = 0; i < guards.Length; i++)
        {
            var r = guards[i][0];
            var c = guards[i][1];

            IterateRows(r - 1, c, -1);
            IterateRows(r + 1, c, 1);
            IterateCols(r, c - 1, -1);
            IterateCols(r, c + 1, 1);
        }

        var unguarded = 0;
        foreach (var row in grid)
        {
            var rowCount = row.Where(x => x == 0).Count();
            unguarded += rowCount;
        }

        return unguarded;
    }
}

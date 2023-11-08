namespace LeetcodeGrind.Solutions;

// 980. Unique Paths III
public class P0980
{
    public int UniquePathsIII(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var startR = -1;
        var startC = -1;
        var obs = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == -1)
                {
                    obs++;
                }
                else if (grid[r][c] == 1)
                {
                    startR = r;
                    startC = c;
                }
            }
        }

        // number of empty squares
        var numEmpty = rows * cols - obs;
        var count = 0;
        var visited = new bool[rows][];
        for (int r = 0; r < rows; r++)
            visited[r] = new bool[cols];

        void Backtrack(int r, int c, int numVisited)
        {
            if (r < 0 || r == rows) return;
            if (c < 0 || c == cols) return;
            if (visited[r][c] || grid[r][c] == -1) return;

            numVisited++;
            if (grid[r][c] == 2)
            {
                if (numVisited == numEmpty)
                    count++;
                numVisited--;
                return;
            }

            visited[r][c] = true;

            Backtrack(r - 1, c, numVisited);
            Backtrack(r + 1, c, numVisited);
            Backtrack(r, c - 1, numVisited);
            Backtrack(r, c + 1, numVisited);

            visited[r][c] = false;
            numVisited--;
        }

        Backtrack(startR, startC, 0);

        return count;
    }
}

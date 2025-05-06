namespace LeetcodeGrind.Solutions;

// 1267. Count Servers that Communicate
public class P1267
{
    public int CountServers(int[][] grid)
    {
        var hs = new HashSet<(int, int)>();
        for (int r = 0; r < grid.Length; r++)
        {
            var cells = new List<(int, int)>();
            for (int c = 0; c < grid[r].Length; c++)
            {
                if (grid[r][c] == 1)
                {
                    cells.Add((r, c));
                }
            }

            if (cells.Count >= 2)
            {
                foreach (var cell in cells)
                {
                    hs.Add(cell);
                }
            }

            cells.Clear();
        }

        for (int c = 0; c < grid[0].Length; c++)
        {
            var cells = new List<(int, int)>();
            for (int r = 0; r < grid.Length; r++)
            {
                if (grid[r][c] == 1)
                {
                    cells.Add((r, c));
                }
            }

            if (cells.Count >= 2)
            {
                foreach (var cell in cells)
                {
                    hs.Add(cell);
                }
            }

            cells.Clear();
        }

        return hs.Count;
    }
}

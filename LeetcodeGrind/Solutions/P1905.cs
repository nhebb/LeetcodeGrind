namespace LeetcodeGrind.Solutions;

// 1905. Count Sub Islands
public class P1905
{
    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        var visited = new HashSet<(int, int)>();
        var islands2 = new List<HashSet<(int, int)>>();

        var rows = grid2.Length;
        int cols = grid2[0].Length;

        bool IsInbounds(int r, int c)
        {
            if (r < 0 || c < 0 || r >= rows || c >= cols)
                return false;
            return true;
        }

        void Bfs(HashSet<(int, int)> island, int r, int c)
        {
            if (!IsInbounds(r, c) ||
                visited.Contains((r, c)) ||
                grid2[r][c] == 0)
                return;

            visited.Add((r, c));
            island.Add((r, c));

            Bfs(island, r + 1, c);
            Bfs(island, r - 1, c);
            Bfs(island, r, c + 1);
            Bfs(island, r, c - 1);
        }

        bool IsSubset(HashSet<(int row, int col)> hs)
        {
            foreach (var cell in hs)
            {
                if (grid1[cell.row][cell.col] == 0)
                    return false;
            }
            return true;
        }

        // Build List of islands 
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid2[r][c] == 0 || visited.Contains((r, c)))
                    continue;

                var island = new HashSet<(int, int)>();
                Bfs(island, r, c);
                if (island.Count > 0)
                {
                    islands2.Add(island);
                }
            }
        }

        var count = 0;
        foreach (var hs2 in islands2)
        {
            if (IsSubset(hs2))
            {
                count++;
            }
        }

        return count;
    }
}

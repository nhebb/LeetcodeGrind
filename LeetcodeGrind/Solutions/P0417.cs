namespace LeetcodeGrind.Solutions;

// 417. Pacific Atlantic Water Flow
public class P0417
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        // pac = left & top
        var pac = new bool[heights.Length][];
        for (int i = 0; i < pac.Length; i++)
            pac[i] = new bool[heights[0].Length];

        // atl = right & bottom
        var atl = new bool[heights.Length][];
        for (int i = 0; i < atl.Length; i++)
            atl[i] = new bool[heights[0].Length];

        // initialize top / left edges
        Array.Fill(pac[0], true);
        for (int r = 1; r < pac.Length; r++)
            pac[r][0] = true;

        // initialize bottom / right edges
        Array.Fill(atl[atl.Length - 1], true);
        for (int r = 0; r < atl.Length - 1; r++)
            atl[r][atl[0].Length - 1] = true;

        // set pacific flow
        for (int r = 1; r < pac.Length; r++)
        {
            // first pass - check above
            for (int c = 1; c < pac[r].Length; c++)
            {
                pac[r][c] = pac[r - 1][c] &&
                            heights[r][c] >= heights[r - 1][c];
            }

            // second pass - scan left to right
            for (int c = 1; c < pac[r].Length; c++)
            {
                if (pac[r][c]) continue;

                pac[r][c] = pac[r][c - 1] &&
                            heights[r][c - 1] <= heights[r][c];
            }

            // third pass - scan right to left
            for (int c = pac[r].Length - 2; c >= 0; c--)
            {
                if (pac[r][c]) continue;

                pac[r][c] = c < pac[r].Length - 1 && pac[r][c + 1] &&
                            heights[r][c + 1] <= heights[r][c];
            }
        }

        // set atlantic flow
        for (int r = atl.Length - 2; r >= 0; r--)
        {
            // first pass - check below
            for (int c = 0; c < atl[r].Length - 1; c++)
            {
                atl[r][c] = atl[r + 1][c] &&
                            heights[r][c] >= heights[r + 1][c];
            }

            // second pass - check left to right
            for (int c = 1; c < atl[r].Length - 1; c++)
            {
                if (atl[r][c]) continue;

                atl[r][c] = atl[r][c - 1] &&
                            heights[r][c - 1] <= heights[r][c];
            }

            // second pass - check left and right
            for (int c = atl[r].Length - 2; c >= 0; c--)
            {
                if (atl[r][c]) continue;

                atl[r][c] = atl[r][c + 1] &&
                            heights[r][c + 1] <= heights[r][c];
            }
        }

        var ans = new List<IList<int>>();
        for (int r = 0; r < heights.Length; r++)
        {
            for (int c = 0; c < heights[r].Length; c++)
            {
                if (pac[r][c] && atl[r][c])
                    ans.Add(new List<int>() { r, c });
            }
        }

        return ans;
    }
    public IList<IList<int>> PacificAtlantic2(int[][] heights)
    {
        var result = new List<IList<int>>();

        var rows = heights.Length;
        var cols = heights[0].Length;

        // track visited
        var pac = new bool[rows, cols];
        var atl = new bool[rows, cols];

        void Dfs(int r, int c, int lastHeight, bool[,] visited)
        {
            if (r < 0 || c < 0 ||
                r == rows || c == cols ||
                visited[r, c] ||
                heights[r][c] < lastHeight)
            {
                return;
            }

            visited[r, c] = true;
            lastHeight = heights[r][c];
            Dfs(r + 1, c, lastHeight, visited);
            Dfs(r - 1, c, lastHeight, visited);
            Dfs(r, c + 1, lastHeight, visited);
            Dfs(r, c - 1, lastHeight, visited);
        }

        // scan from top and bottom rows
        for (var col = 0; col < cols; col++)
        {
            Dfs(0, col, heights[0][col], pac);
            Dfs(rows - 1, col, heights[rows - 1][col], atl);
        }

        // scan from left and right columns
        for (var r = 0; r < rows; r++)
        {
            Dfs(r, 0, heights[r][0], pac);
            Dfs(r, cols - 1, heights[r][cols - 1], atl);
        }

        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                if (pac[r, c] && atl[r, c])
                    result.Add(new List<int>() { r, c });
            }
        }

        return result;
    }
}

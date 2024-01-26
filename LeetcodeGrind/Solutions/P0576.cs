namespace LeetcodeGrind.Solutions;

// 576. Out of Boundary Paths
public class P0576
{
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
    {
        const int mod = 1_000_000_007;

        // Create a 3D matrix (row, column, # moves) to cache results.
        // Since cached results will be >= 0, initialize w/ -1.
        var dp = new int[m, n, maxMove + 1];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k <= maxMove; k++)
                {
                    dp[i, j, k] = -1;
                }
            }
        }

        // Local recursive function
        int Dfs(int movesLeft, int r, int c)
        {
            // Out of bounds - reached goal
            if (r < 0 || c < 0 || r >= m || c >= n)
            {
                return 1;
            }

            // Dead end
            if (movesLeft == 0)
            {
                return 0;
            }

            // Check cache for precalculated result
            if (dp[r, c, movesLeft] != -1)
            {
                return dp[r, c, movesLeft];
            }

            // Add the results for up, down, left, right
            long count = 0;
            count = (count + Dfs(movesLeft - 1, r - 1, c)) % mod;
            count = (count + Dfs(movesLeft - 1, r + 1, c)) % mod;
            count = (count + Dfs(movesLeft - 1, r, c - 1)) % mod;
            count = (count + Dfs(movesLeft - 1, r, c + 1)) % mod;

            // Cache result
            dp[r, c, movesLeft] = (int)count;

            return dp[r, c, movesLeft];
        }

        // Call the recursive function at the start point
        return Dfs(maxMove, startRow, startColumn);
    }
}

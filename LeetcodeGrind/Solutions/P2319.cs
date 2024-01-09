namespace LeetcodeGrind.Solutions;

// 2319. Check if Matrix Is X-Matrix
public class P2319
{
    public bool CheckXMatrix(int[][] grid)
    {
        var n = grid.Length;

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                var isDiagonal = r == c || c == n - r - 1;
                var isZero = grid[r][c] == 0;

                if ((isDiagonal && isZero) ||
                    (!isDiagonal && !isZero))
                {
                    return false;
                }
            }
        }

        return true;
    }
}

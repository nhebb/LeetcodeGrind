namespace LeetcodeGrind.Solutions;

// 1162. As Far from Land as Possible
public class P1162
{
    public int MaxDistance(int[][] grid)
    {
        var searchVal = 1;
        var markVal = 2;
        var maxDist = 0;
        var hasZeroes = true;
        var lastRow = grid.Length - 1;
        var lastCol = grid[0].Length - 1;

        while (hasZeroes)
        {
            hasZeroes = false;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] != searchVal) continue;

                    var updated = false;
                    if (r > 0 && grid[r - 1][c] == 0)
                    {
                        grid[r - 1][c] = markVal;
                        updated = true;
                    }
                    if (r < lastRow && grid[r + 1][c] == 0)
                    {
                        grid[r + 1][c] = markVal;
                        updated = true;
                    }
                    if (c > 0 && grid[r][c - 1] == 0)
                    {
                        grid[r][c - 1] = markVal;
                        updated = true;
                    }
                    if (c < lastCol && grid[r][c + 1] == 0)
                    {
                        grid[r][c + 1] = markVal;
                        updated = true;
                    }
                    if (updated)
                    {
                        hasZeroes = true;
                        if (markVal > maxDist)
                            maxDist = markVal;
                    }
                }
            }
            searchVal++;
            markVal++;
        }

        // markVal is always 1 greater than the distance, so
        // decrement by 1 when returning
        return maxDist - 1;
    }
}

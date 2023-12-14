namespace LeetcodeGrind.Solutions;

// 2482. Difference Between Ones and Zeros in Row and Column
public class P2482
{
    public int[][] OnesMinusZeros(int[][] grid)
    {
        var rowVals = new int[grid.Length];
        var colVals = new int[grid[0].Length];
        for (int c = 0; c < grid[0].Length; c++)
        {
            for (int r = 0; r < grid.Length; r++)
            {
                if (grid[r][c] == 1)
                {
                    rowVals[r]++;
                    colVals[c]++;
                }
                else
                {
                    rowVals[r]--;
                    colVals[c]--;
                }
            }
        }

        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[r].Length; c++)
            {
                grid[r][c] = rowVals[r] + colVals[c];
            }
        }

        return grid;
    }
}

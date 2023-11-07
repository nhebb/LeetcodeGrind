namespace LeetcodeGrind.Solutions;

// 2482. Difference Between Ones and Zeros in Row and Column
public class P2482
{
    public int[][] OnesMinusZeros(int[][] grid)
    {
        var diff = new int[grid.Length][];
        for (int r = 0; r < grid.Length; r++)
        {
            diff[r] = new int[grid[r].Length];
        }

        var rowVals = new int[grid.Length];
        for (int i = 0; i < grid.Length; i++)
        {
            rowVals[i] = grid[i].Count(x => x == 1) -
                         grid[i].Count(x => x == 0);
        }

        var colVals = new int[grid[0].Length];
        for (int c = 0; c < grid[0].Length; c++)
        {
            for (int r = 0; r < grid.Length; r++)
            {
                if (grid[r][c] == 1)
                    colVals[c]++;
                else if (grid[r][c] == 0)
                    colVals[c]--;
            }
        }

        for (int r = 0; r < diff.Length; r++)
        {
            for (int c = 0; c < diff[r].Length; c++)
            {
                diff[r][c] = rowVals[r] + colVals[c];
            }
        }

        return diff;
    }
}

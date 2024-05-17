namespace LeetcodeGrind.Solutions;

// 861. Score After Flipping Matrix
public class P0861
{
    public int MatrixScore(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        foreach (var row in grid)
        {
            if (row[0] == 1)
                continue;

            for (int c = 0; c < cols; c++)
            {
                row[c] ^= 1;
            }
        }

        var target = rows % 2 == 0
            ? rows / 2
            : rows / 2 + 1;

        for (int c = 1; c < cols; c++)
        {
            var ones = 0;
            for (int r = 0; r < rows; r++)
            {
                ones += grid[r][c];
            }

            if (ones >= target)
                continue;

            for (int r = 0; r < rows; r++)
            {
                grid[r][c] ^= 1;
            }
        }

        var sum = 0;
        foreach (var row in grid)
        {
            var val = 0;
            foreach (var bit in row)
            {
                val *= 2;
                val += bit;
            }
            sum += val;
        }

        return sum;
    }
}

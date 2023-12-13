using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1260. Shift 2D Grid
public class P1260
{
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var size = rows * cols;

        var result = new int[rows][];
        for (int r = 0; r < rows; r++)
        {
            result[r] = new int[cols];
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                var position = r * cols + c;
                position = (position + k) % size;
                var row = position / cols;
                var col = position % cols;
                result[row][col] = grid[r][c];
            }
        }

        return result;
    }
}

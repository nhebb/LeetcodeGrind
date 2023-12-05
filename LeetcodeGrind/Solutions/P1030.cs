namespace LeetcodeGrind.Solutions;

// 1030. Matrix Cells in Distance Order
public class P1030
{
    public int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
    {
        int[][] result = new int[rows * cols][];
        int[][] distances = new int[rows * cols][];

        for (int r = 0, i = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++, i++)
            {
                var distance = Math.Abs(r - rCenter) + Math.Abs(c - cCenter);
                distances[i] = new int[] { r, c, distance };
            }
        }

        Array.Sort(distances, (a, b) => a[2] - b[2]);

        for (int i = 0; i < rows * cols; i++)
        {
            var r = distances[i][0];
            var c = distances[i][1];
            result[i] = new int[] { r, c };
        }

        return result;
    }
}

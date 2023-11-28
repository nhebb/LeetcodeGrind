namespace LeetcodeGrind.Solutions;

// 867. Transpose Matrix
public class P0867
{
    public int[][] Transpose(int[][] matrix)
    {
        var transposed = new int[matrix[0].Length][];

        for (int r = 0; r < transposed.Length; r++)
        {
            transposed[r] = new int[matrix.Length];
        }

        for (int r = 0; r < matrix.Length; r++)
        {
            for (int c = 0; c < matrix[r].Length; c++)
            {
                transposed[c][r] = matrix[r][c];
            }
        }

        return transposed;
    }
}

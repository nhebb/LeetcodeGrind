namespace LeetcodeGrind.Solutions;

// 3033. Modify the Matrix
public class P3033
{
    public int[][] ModifiedMatrix(int[][] matrix)
    {
        var result = new int[matrix.Length][];
        for (int r = 0; r < result.Length; r++)
        {
            result[r] = new int[matrix[0].Length];
        }

        for (int c = 0; c < matrix[0].Length; c++)
        {
            var colMax = int.MinValue;
            var negOneRows = new List<int>();

            for (int r = 0; r < matrix.Length; r++)
            {
                result[r][c] = matrix[r][c];
                colMax = Math.Max(colMax, matrix[r][c]);
                if (matrix[r][c] == -1)
                {
                    negOneRows.Add(r);
                }
            }

            foreach (var r in negOneRows)
            {
                result[r][c] = colMax;
            }

            negOneRows.Clear();
        }

        return result;
    }
}

namespace LeetcodeGrind.Solutions;

// 1380. Lucky Numbers in a Matrix
public class P1380
{
    public IList<int> LuckyNumbers(int[][] matrix)
    {
        var rowMin = new int[matrix.Length];
        var colMax = new int[matrix[0].Length];

        for (int r = 0; r < matrix.Length;r++)
        {
            rowMin[r] = matrix[r].Min();
        }

        for (int c = 0; c < matrix[0].Length; c++)
        {
            colMax[c] = matrix[0][c];
            for (int r = 1; r < matrix.Length; r++)
            {
                colMax[c] = Math.Max(colMax[c], matrix[r][c]);
            }
        }

        var result = new List<int>();
        for (int r = 0; r < matrix.Length; r++)
        {
            for (int c = 0; c < matrix[r].Length; c++)
            {
                var val = matrix[r][c];
                if (val == rowMin[r] && val == colMax[c])
                {
                    result.Add(val);
                }
            }
        }

        return result;
    }
}

namespace LeetcodeGrind.Solutions;

// 1582. Special Positions in a Binary Matrix
public class P1582
{
    public int NumSpecial(int[][] mat)
    {
        var specialRows = new bool[mat.Length];
        var specialCols = new bool[mat[0].Length];

        for (int r = 0; r < mat.Length; r++)
        {
            var rowSum = 0;
            for (int c = 0; c < mat[0].Length; c++)
            {
                rowSum += mat[r][c];
            }
            specialRows[r] = rowSum == 1;
        }

        for (int c = 0; c < mat[0].Length; c++)
        {
            var colSum = 0;
            for (int r = 0; r < mat.Length; r++)
            {
                colSum += mat[r][c];
            }
            specialCols[c] = colSum == 1;
        }

        var count = 0;
        for (int r = 0; r < mat.Length; r++)
        {
            for (int c = 0; c < mat[0].Length; c++)
            {
                if (mat[r][c] == 1 && specialRows[r] && specialCols[c])
                {
                    count++;
                }
            }
        }

        return count;
    }
}

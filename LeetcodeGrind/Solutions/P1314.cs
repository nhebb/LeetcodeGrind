namespace LeetcodeGrind.Solutions;

// 1314. Matrix Block Sum
public class P1314
{
    public int[][] MatrixBlockSum(int[][] mat, int k)
    {
        int GetSum(int i, int j)
        {
            var firstRow = Math.Max(i - k, 0);
            var firstCol = Math.Max(j - k, 0);
            var lastRow = Math.Min(i + k, mat.Length - 1);
            var lastCol = Math.Min(j + k, mat[0].Length - 1);

            var sum = 0;
            for (int r = firstRow; r <= lastRow; r++)
                for (int c = firstCol; c <= lastCol; c++)
                    sum += mat[r][c];

            return sum;
        }

        var ans = new int[mat.Length][];
        for (int r = 0; r < mat.Length; r++)
        {
            ans[r] = new int[mat[r].Length];
            for (int c = 0; c < mat[r].Length; c++)
                ans[r][c] = GetSum(r, c);
        }

        return ans;
    }
}

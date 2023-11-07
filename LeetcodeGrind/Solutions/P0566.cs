namespace LeetcodeGrind.Solutions;

// 566. Reshape the Matrix
public class P0566
{
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        var r0 = mat.Length;
        var c0 = mat[0].Length;

        if (r * c != r0 * c0)
            return mat;

        var ans = new int[r][];
        ans[0] = new int[c];
        int r1 = 0;
        int c1 = 0;

        for (int i = 0; i < r0; i++)
        {
            for (int j = 0; j < c0; j++)
            {
                ans[r1][c1] = mat[i][j];
                c1++;
                if (c1 == c)
                {
                    r1++;
                    c1 = 0;
                    ans[r1] = new int[c];
                }
            }
        }

        return ans;
    }
}

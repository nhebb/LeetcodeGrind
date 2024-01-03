namespace LeetcodeGrind.Solutions;

// 2946. Matrix Similarity After Cyclic Shifts
public class P2946
{
    public bool AreSimilar(int[][] mat, int k)
    {
        var n = mat[0].Length;
        k = k % n;
        if (k == 0 || k == n)
        {
            return true;
        }

        for (int r = 0; r < mat.Length; r++)
        {
            var isOdd = r % 2 == 1;
            for (int c1 = 0; c1 < n; c1++)
            {
                int c2 = isOdd
                    ? (c1 + k) % n
                    : (c1 - k + n) % n;

                if (mat[r][c1] != mat[r][c2])
                {
                    return false;
                }
            }
        }

        return true;
    }
}

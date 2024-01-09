namespace LeetcodeGrind.Solutions;

// 1886. Determine Whether Matrix Can Be Obtained By Rotation
public class P1886
{
    public bool FindRotation(int[][] mat, int[][] target)
    {
        var canRotate = new bool[4];
        Array.Fill(canRotate, true);

        var n = mat.Length;

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (mat[r][c] != target[r][c])
                    canRotate[0] = false;

                if (mat[r][c] != target[n - c - 1][r])
                    canRotate[1] = false;

                if (mat[r][c] != target[n - r - 1][n - c - 1])
                    canRotate[2] = false;

                if (mat[r][c] != target[c][n - r - 1])
                    canRotate[3] = false;
            }
        }

        return canRotate[0] ||
               canRotate[1] ||
               canRotate[2] ||
               canRotate[3];
    }
}

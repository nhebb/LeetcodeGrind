namespace LeetcodeGrind.Solutions;

// 59. Spiral Matrix II
public class P0059
{
    public int[][] GenerateMatrix(int n)
    {
        var matrix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }

        var count = 1;
        var offset = 0;
        var total = n * n;
        var r = 0;
        var c = 0;

        while (count <= total)
        {
            // special case for last cell in odd-length matrix
            if (count == total && n % 2 == 1)
            {
                matrix[n / 2][n / 2] = total;
                break;
            }

            r = offset;
            c = offset;

            // top row
            while (count <= total && c < n - 1 - offset)
            {
                matrix[r][c] = count;
                count++;
                c++;
            }

            // right column
            while (count <= total && r < n - 1 - offset)
            {
                matrix[r][c] = count;
                count++;
                r++;
            }

            // bottom row
            while (count <= total && c > offset)
            {
                matrix[r][c] = count;
                count++;
                c--;
            }

            // left column
            while (count <= total && r > offset)
            {
                matrix[r][c] = count;
                count++;
                r--;
            }

            offset++;
        }
        //PrintMatrix(matrix);
        return matrix;
    }
}

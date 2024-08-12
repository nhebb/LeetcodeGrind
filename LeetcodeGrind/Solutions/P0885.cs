using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 885. Spiral Matrix III
public class P0885
{
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        var total = rows * cols;
        var visited = 1;
        var result = new List<int[]>();
        result.Add([rStart, cStart]);

        var r = rStart;
        var minR = r - 1;
        var maxR = r + 1;

        var c = cStart;
        var minC = c - 1;
        var maxC = c + 1;


        bool InBounds(int r, int c)
        {
            return r >= 0 && r < rows && c >= 0 && c < cols;
        }

        while (visited < total)
        {
            while (c < maxC && visited < total)
            {
                c++;
                if (InBounds(r,c))
                {
                    visited++;
                    result.Add([r, c]);
                }
            }
            maxC++;

            while (r < maxR && visited < total)
            {
                r++;
                if (InBounds(r, c))
                {
                    visited++;
                    result.Add([r, c]);
                }
            }
            maxR++;

            while (c > minC && visited < total)
            {
                c--;
                if (InBounds(r, c))
                {
                    visited++;
                    result.Add([r, c]);
                }
            }
            minC--;

            while (r > minR && visited < total)
            {
                r--;
                if (InBounds(r, c))
                {
                    visited++;
                    result.Add([r, c]);
                }
            }
            minR--;
        }

        return result.ToArray();
    }
}

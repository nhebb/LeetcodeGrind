using LeetcodeGrind.Common;
using System.Diagnostics;

namespace LeetcodeGrind.Solutions;

// 1232. Check If It Is a Straight Line
public class P1232
{
    public bool CheckStraightLine(int[][] coordinates)
    {
        Array.Sort(coordinates, (a, b) => a[0] - b[0]);

        var x0 = coordinates[0][0];
        var y0 = coordinates[0][1];

        // Check for vertical line to avoid divide-by-zero error
        var sameX = true;
        for (int r = 1; r < coordinates.Length; r++)
        {
            if (coordinates[r][0] != x0)
            {
                sameX = false; 
                break;
            }
        }
        if (sameX)
        {
            return true;
        }

        double slope = (coordinates[^1][1] - y0) / (double)(coordinates[^1][0] - x0);

        for (int i = 1; i < coordinates.Length; i++)
        {
            if ((coordinates[i][1] - y0) / (double)(coordinates[i][0] - x0) != slope)
            {
                return false;
            }
        }

        return true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.MathAndGeometry;

public class MathAndGeometry
{
    // 1037. Valid Boomerang
    public bool IsBoomerang(int[][] points)
    {
        if ((points[0][0] == points[1][0] && points[0][1] == points[1][1]) ||
            points[0][0] == points[2][0] && points[0][1] == points[2][1] ||
            points[2][0] == points[1][0] && points[2][1] == points[1][1] ||
            points[0][0] == points[1][0] && points[1][0] == points[2][0] ||
            points[0][1] == points[1][1] && points[1][1] == points[2][1])
        {
            return false;
        }

        var slope1 = (points[1][1] - points[0][1]) / ((double)(points[1][0] - points[0][0]));
        var slope2 = (points[2][1] - points[1][1]) / ((double)(points[2][0] - points[1][0]));

        return Math.Abs(slope1 - slope2) > double.Epsilon;
    }


    // 2028. Find Missing Observations
    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
        // (rolls.Sum() + missing.Sum()) / (m + n) = mean
        // missing.Sum() = mean * (m + n) - rolls.Sum()
        var missingTotal = mean * (rolls.Length + n) - rolls.Sum();
        var ans = new int[n];
        Array.Fill(ans, 1);
        missingTotal -= n;

        while (missingTotal > 0)
        {
            for (int i = 0; i < n && missingTotal > 0; i++)
            {
                ans[i]++;
                missingTotal--;
            }
        }

        var impossible = ans.Any(x => x > 6) ||
                         (rolls.Sum() + ans.Sum()) / ((double)(rolls.Length + n)) > mean;
        if (impossible)
            return Array.Empty<int>();
        return ans;
    }
}

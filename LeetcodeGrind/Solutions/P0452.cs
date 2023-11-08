namespace LeetcodeGrind.Solutions;

// 452. Minimum Number of Arrows to Burst Balloons
public class P0452
{
    public int FindMinArrowShots(int[][] points)
    {
        Array.Sort(points, (x, y) => x[1].CompareTo(y[1]));
        var lastEnd = points[0][1];
        var count = 1;

        for (int i = 1; i < points.Length; i++)
        {
            if (points[i][0] <= lastEnd)
                continue;
            count++;
            lastEnd = points[i][1];
        }

        return count;
    }
}

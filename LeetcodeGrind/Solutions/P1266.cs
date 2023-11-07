namespace LeetcodeGrind.Solutions;

// 1266. Minimum Time Visiting All Points
public class P1266
{
    public int MinTimeToVisitAllPoints(int[][] points)
    {
        var time = 0;
        for (int i = 0; i < points.Length - 1; i++)
        {
            var dx = Math.Abs(points[i + 1][0] - points[i][0]);
            var dy = Math.Abs(points[i + 1][1] - points[i][1]);
            time += dx > dy ? dx : dy;
        }
        return time;
    }
}

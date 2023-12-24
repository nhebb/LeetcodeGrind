namespace LeetcodeGrind.Solutions;

// 1637. Widest Vertical Area Between Two Points Containing No Points
public class P1637
{
    public int MaxWidthOfVerticalArea(int[][] points)
    {
        Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));
        var maxDx = 0;

        for (int i = 1; i < points.Length; i++)
        {
            maxDx = Math.Max(maxDx, points[i][0] - points[i - 1][0]);
        }

        return maxDx;
    }
}

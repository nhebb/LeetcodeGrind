namespace LeetcodeGrind.Solutions;

// 1637. Widest Vertical Area Between Two Points Containing No Points
public class P1637
{
    public int MaxWidthOfVerticalArea(int[][] points)
    {
        var sortedPoints = points.OrderBy(x => x[0]).ToArray();

        var maxDx = 0;

        for (int i = 1; i < sortedPoints.Count(); i++)
        {
            maxDx = Math.Max(maxDx, sortedPoints[i][0] - sortedPoints[i - 1][0]);
        }

        return maxDx;
    }
}

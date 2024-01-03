namespace LeetcodeGrind.Solutions;

// 1779. Find Nearest Point That Has the Same X or Y Coordinate
public class P1779
{
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        var index = -1;
        var min = int.MaxValue;

        for (int i = 0; i < points.Length; i++)
        {
            if (points[i][0] == x || points[i][1] == y)
            {
                var dist = Math.Abs(points[i][0] - x) + 
                           Math.Abs(points[i][1] - y);

                if (dist < min)
                {
                    index = i;
                    min = dist;
                }
            }
        }

        return index;
    }
}

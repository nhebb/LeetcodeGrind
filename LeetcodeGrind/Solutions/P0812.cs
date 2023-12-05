namespace LeetcodeGrind.Solutions;

// 812. Largest Triangle Area
public class P0812
{
    public double LargestTriangleArea(int[][] points)
    {
        var max = 0.0;

        for (int i = 0; i < points.Length - 2; i++)
        {
            var x1 = points[i][0];
            var y1 = points[i][1];

            for (int j = i + 1; j < points.Length - 1; j++)
            {
                var x2 = points[j][0];
                var y2 = points[j][1];

                for (int k = j + 1; k < points.Length; k++)
                {
                    var x3 = points[k][0];
                    var y3 = points[k][1];

                    var area = 0.5 * Math.Abs(x1 * (y2 - y3) +
                                              x2 * (y3 - y1) +
                                              x3 * (y1 - y2));

                    max = Math.Max(area, max);
                }
            }
        }

        return max;
    }
}

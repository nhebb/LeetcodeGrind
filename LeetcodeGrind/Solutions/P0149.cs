namespace LeetcodeGrind.Solutions;

// 149. Max Points on a Line
public class P0149
{
    public int MaxPoints(int[][] points)
    {
        if (points.Length <= 2)
            return points.Length;

        var lines = new Dictionary<(double, double), HashSet<(int, int)>>();
        var maxPoints = 2;

        for (int i = 0; i < points.Length - 1; i++)
        {
            var x1 = points[i][0];
            var y1 = points[i][1];

            for (int j = i + 1; j < points.Length; j++)
            {
                var x2 = points[j][0];
                var y2 = points[j][1];
                var dy = y2 - y1;
                var dx = (double)(x2 - x1);
                var slope = Math.Round(dy / dx, 5);

                var key = (x1 == x2)
                    ? (double.PositiveInfinity, x1)
                    : (slope, y1 - slope * x1);

                if (lines.TryGetValue(key, out var hs))
                {
                    hs.Add((x1, y1));
                    hs.Add((x2, y2));
                }
                else
                {
                    lines[key] = new HashSet<(int, int)>();
                    lines[key].Add((x1, y1));
                    lines[key].Add((x2, y2));
                }
                maxPoints = Math.Max(maxPoints, lines[key].Count);
            }
        }

        return maxPoints;
    }
}

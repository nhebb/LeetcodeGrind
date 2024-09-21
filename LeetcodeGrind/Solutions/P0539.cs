namespace LeetcodeGrind.Solutions;

// 539. Minimum Time Difference
public class P0539
{
    public int FindMinDifference(IList<string> timePoints)
    {
        var times = new int[timePoints.Count];

        for (int i = 0; i < timePoints.Count; i++)
        {
            var hh = int.Parse(timePoints[i].Substring(0, 2));
            var mm = int.Parse(timePoints[i].Substring(3, 2));
            times[i] = hh * 60 + mm;
        }

        Array.Sort(times);

        // shortest "wrap around the clock" time.
        var min = times[0] + 24 * 60 - times[^1];

        for (int i = 1; i < times.Length; i++)
        {
            min = Math.Min(min, times[i] - times[i - 1]);
        }

        return min;
    }
}

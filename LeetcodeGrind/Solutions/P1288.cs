namespace LeetcodeGrind.Solutions;

// 1288. Remove Covered Intervals
public class P1288
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        if (intervals.Length == 1)
            return 1;

        var sorted = intervals.OrderBy(x => x[0])
                              .ThenBy(x => x[1])
                              .ToList();

        var count = 1;
        int i = 0;
        int j = 1;
        while (j < sorted.Count)
        {
            if (sorted[i][0] >= sorted[j][0] && sorted[i][1] <= sorted[j][1])
            {
                i++;
                j++;
            }
            else if (sorted[j][0] >= sorted[i][0] && sorted[j][1] <= sorted[i][1])
            {
                j++;
            }
            else
            {
                count++;
                if (i > 0 && j + 1 == sorted.Count - 1)
                {
                    count++;
                }
                i = j;
                j = i + 1;
            }
        }

        return count;
    }
}

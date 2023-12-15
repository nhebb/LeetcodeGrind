namespace LeetcodeGrind.Solutions;

// 2848. Points That Intersect With Cars
public class P2848
{
    public int NumberOfPoints(IList<IList<int>> nums)
    {
        var sorted = nums.OrderBy(x => x[0])
                         .ThenBy(x => x[1])
                         .ToList();

        var intervals = new List<IList<int>>();
        intervals.Add(sorted[0]);

        // Merge overlapping intervals
        for (int i = 1; i < sorted.Count; i++)
        {
            if (sorted[i][0] <= intervals[^1][1])
            {
                intervals[^1][1] = Math.Max(intervals[^1][1], sorted[i][1]);
            }
            else
            {
                intervals.Add(sorted[i]);
            }
        }

        var points = 0;
        foreach (var interval in intervals)
        {
            points += interval[1] - interval[0] + 1;
        }

        return points;
    }
}

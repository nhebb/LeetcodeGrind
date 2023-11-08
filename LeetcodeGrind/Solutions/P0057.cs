namespace LeetcodeGrind.Solutions;

// 57. Insert Interval
public class P0057
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var res = new List<int[]>();
        if (intervals.Length == 0)
        {
            res.Add(newInterval);
            return res.ToArray();
        }

        bool newAdded = false;

        for (int i = 0; i < intervals.Length; i++)
        {
            // new interval already added to result
            if (newAdded)
            {
                res.Add(intervals[i]);
            }
            else if (intervals[i][^1] < newInterval[0])
            {
                res.Add(intervals[i]);
            }
            // new comes before existing
            else if (newInterval[^1] < intervals[i][0])
            {
                res.Add(newInterval);
                newAdded = true;
                res.Add(intervals[i]);
            }
            else
            {
                var min = Math.Min(newInterval[0], intervals[i][0]);
                var max = Math.Max(newInterval[^1], intervals[i][^1]);
                newInterval[0] = min;
                newInterval[1] = max;
                if (i == intervals.Length - 1)
                {
                    res.Add(newInterval);
                    newAdded = true;
                }
            }
        }

        if (!newAdded)
            res.Add(newInterval);

        return res.ToArray();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Intervals;

public class Intervals
{
    // 56. Merge Intervals
    public int[][] Merge(int[][] intervals)
    {
        var list = new List<int[]>(intervals).OrderBy(x => x[0]).ToList();
        var skiplist = new HashSet<int>();

        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i][1] >= list[i + 1][0])
            {
                list[i + 1][0] = Math.Min(list[i][0], list[i + 1][0]);
                list[i + 1][1] = Math.Max(list[i][1], list[i + 1][1]);
                skiplist.Add(i);
            }
        }

        var res = new List<int[]>();
        for (int i = 0; i < list.Count; i++)
        {
            if (!skiplist.Contains(i))
            {
                res.Add(list[i]);
            }
        }

        return res.ToArray();
    }


    // 57. Insert Interval
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


    // 920. Meeting Rooms
    // https://www.lintcode.com/problem/920/
    public bool CanAttendMeetings(List<Interval> intervals)
    {
        var ordered = intervals.OrderBy(x => x.start).ToList();
        for (int i = 1; i < ordered.Count; i++)
        {
            if (ordered[i].start < ordered[i - 1].end)
            {
                return false;
            }
        }
        return true;
    }


    // 919. Meeting Rooms II
    // https://www.lintcode.com/problem/919/
    public int MinMeetingRooms(List<Interval> intervals)
    {
        var countsByHour = new Dictionary<int, int>();
        foreach (var interval in intervals)
        {
            for (int i = interval.start; i < interval.end; i++)
            {
                if (countsByHour.TryGetValue(i, out int value))
                    countsByHour[i] = value + 1;
                else
                    countsByHour[i] = 1;
            }
        }
        return countsByHour.Values.Max();
    }


    // 452. Minimum Number of Arrows to Burst Balloons
    public int FindMinArrowShots(int[][] points)
    {
        Array.Sort(points, (x, y) => x[1].CompareTo(y[1]));
        var lastEnd = points[0][1];
        var count = 1;

        for (int i = 1; i < points.Length; i++)
        {
            if (points[i][0] <= lastEnd)
                continue;
            count++;
            lastEnd = points[i][1];
        }

        return count;
    }
}

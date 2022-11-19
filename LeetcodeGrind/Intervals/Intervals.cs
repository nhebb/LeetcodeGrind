using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Intervals;

public class Intervals
{
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
            var countsByHour = new Dictionary <int, int>();
            foreach (var interval in intervals)
            {
                for (int i = interval.start; i < interval.end; i++)
                {
                    if(countsByHour.TryGetValue(i, out int value))
                        countsByHour[i] = value + 1;
                    else
                        countsByHour[i] = 1;
                }
            }
            return countsByHour.Values.Max();
    }
}

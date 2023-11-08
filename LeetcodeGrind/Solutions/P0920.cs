using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 920. Meeting Rooms
// https://www.lintcode.com/problem/920/
public class P0920
{
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
}


using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 919. Meeting Rooms II
// https://www.lintcode.com/problem/919/
public class P0919
{
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
}

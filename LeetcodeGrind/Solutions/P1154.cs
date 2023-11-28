using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1154. Day of the Year
public class P1154
{
    public int DayOfYear(string date)
    {
        return DateTime.Parse(date).DayOfYear;
    }
}


using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2224. Minimum Number of Operations to Convert Time
public class P2224
{
    public int ConvertTime(string current, string correct)
    {
        // In one operation you can increase the time current by
        // 1, 5, 15, or 60 minutes.

        var t1 = current.Split(':');
        var h1 = int.Parse(t1[0]);
        var m1 = int.Parse(t1[1]);
        var dt1 = new DateTime(2024, 1, 1, h1, m1, 0);

        var t2 = correct.Split(':');
        var h2 = int.Parse(t2[0]);
        var m2 = int.Parse(t2[1]);
        var dt2 = new DateTime(2024, 1, 1, h2, m2, 0);

        var ts = dt2 - dt1;
        var hours = ts.Hours;

        var ops = hours;

        var minutes = ts.Minutes;
        ops += minutes / 15;
        minutes %= 15;

        ops += minutes / 5;
        minutes %= 5;
        ops += minutes;

        return ops;
    }
}


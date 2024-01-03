namespace LeetcodeGrind.Solutions;

// 2446. Determine if Two Events Have Conflict
public class P2446
{
    public bool HaveConflict(string[] event1, string[] event2)
    {
        // For comparing times, minutes don't have to be
        // converted to hours - we can fudge it.
        double ParseTime(string time)
        {
            return double.Parse(time.Replace(":", "."));
        }

        var start1 = ParseTime(event1[0]);
        var end1 = ParseTime(event1[1]);
        var start2 = ParseTime(event2[0]);
        var end2 = ParseTime(event2[1]);

        return (end1 >= start2 && end1 <= end2) ||
               (end2 >= start1 && end2 <= end1);
    }
}

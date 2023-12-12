namespace LeetcodeGrind.Solutions;

// 1360. Number of Days Between Two Dates
public class P1360
{
    public int DaysBetweenDates(string date1, string date2)
    {
        var dateTime1 = DateTime.Parse(date1);
        var dateTime2 = DateTime.Parse(date2);

        var timespan = dateTime1 < dateTime2
            ? dateTime2 - dateTime1
            : dateTime1 - dateTime2;

        return timespan.Days;
    }
}

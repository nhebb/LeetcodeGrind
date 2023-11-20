namespace LeetcodeGrind.Solutions;

// 1185. Day of the Week
public class P1185
{
    public string DayOfTheWeek(int day, int month, int year)
    {
        var d = new DateTime(year, month, day);
        return d.DayOfWeek.ToString();
    }
}

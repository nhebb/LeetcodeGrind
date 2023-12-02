namespace LeetcodeGrind.Solutions;

// 1507. Reformat Date
public class P1507
{
    public string ReformatDate(string date)
    {
        var parts = date.Split(' ');
        var months = new List<string>() { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        var day = 0;
        for (int i = 0; i < parts.Length; i++)
        {
            if (char.IsLetter(parts[0][i]))
                break;
            day *= 10;
            day += parts[0][i] - '0';
        }
        var DD = day.ToString("00");
        var MM = (months.IndexOf(parts[1]) + 1).ToString("00");

        return $"{parts[2]}-{MM}-{DD}";
    }
}

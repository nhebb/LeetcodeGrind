namespace LeetcodeGrind.Solutions;

// 2678. Number of Senior Citizens
public class P2678
{
    public int CountSeniors(string[] details)
    {
        var count = 0;

        foreach (var detail in details)
        {
            if ((detail[11] - '0') * 10 + detail[12] - '0' > 60)
                count++;
        }

        return count;
    }

    public int CountSeniors2(string[] details)
    {
        return details.Count(s => (s[11] - '0') * 10 + s[12] - '0' > 60);
    }
}

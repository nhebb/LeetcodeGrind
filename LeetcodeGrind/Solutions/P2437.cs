namespace LeetcodeGrind.Solutions;

// 2437. Number of Valid Clock Times
public class P2437
{
    public int CountTime(string time)
    {
        var ans = 1;
        if (time[0] == '?' && time[1] == '?')
        {
            ans *= 24;
        }
        else
        {
            if (time[0] == '?')
            {
                if (time[1] - '0' <= 3)
                    ans *= 3;
                else
                    ans *= 2;
            }
            if (time[1] == '?')
            {
                if (time[0] == '2')
                    ans *= 4;
                else
                    ans *= 10;
            }
        }
        if (time[3] == '?')
            ans *= 6;
        if (time[4] == '?')
            ans *= 10;

        return ans;
    }
}

namespace LeetcodeGrind.Solutions;

// 1221. Split a String in Balanced Strings
public class P1221
{
    public int BalancedStringSplit(string s)
    {
        var count = 0;
        var sum = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'L')
                sum--;
            else
                sum++;

            if (sum == 0)
                count++;
        }

        return count;
    }
}

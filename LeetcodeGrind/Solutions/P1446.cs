namespace LeetcodeGrind.Solutions;

// 1446. Consecutive Characters
public class P1446
{
    public int MaxPower(string s)
    {
        var max = 1;
        var start = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] != s[i - 1])
            {
                var len = i - start;
                max = Math.Max(len, max);
                start = i;
            }
            else if (i == s.Length - 1)
            {
                var len = i - start + 1;
                max = Math.Max(len, max);
            }
        }

        return max;
    }
}

namespace LeetcodeGrind.Solutions;

// 91. Decode Ways
public class P0091
{
    public int NumDecodings(string s)
    {
        if (s[0] == '0') return 0;
        if (s.Length == 1) return 1;

        var dp = new int[s.Length];

        dp[0] = 1;
        var num = (s[0] - '0') * 10 + s[1] - '0';
        if (num >= 10 && num <= 26)
            dp[1] = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == '0')
                dp[i - 1] = 0;
            else
                dp[i] += dp[i - 1];

            if (i + 1 < s.Length)
            {
                num = (s[i] - '0') * 10 + s[i + 1] - '0';
                if (num >= 10 && num <= 26)
                    dp[i + 1] += dp[i - 1];
            }
        }

        return dp[^1];
    }
}

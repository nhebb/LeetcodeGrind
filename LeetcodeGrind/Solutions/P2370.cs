using System.ComponentModel.DataAnnotations;

namespace LeetcodeGrind.Solutions;

// 2370. Longest Ideal Subsequence
public class P2370
{
    public int LongestIdealString(string s, int k)
    {
        var dp = new int[26];

        foreach (var ch in s)
        {
            var i = ch - 'a';
            dp[i]++;

            var lowChar = Math.Max(i - k, 0);
            var highChar = Math.Min(i + k, 25);

            for (int j = lowChar; j <= highChar; j++)
            {
                if (i == j)
                    continue;

                dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }

        return dp.Max();
    }
}

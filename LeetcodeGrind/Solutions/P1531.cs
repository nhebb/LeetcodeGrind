namespace LeetcodeGrind.Solutions;

// 1531. String Compression II
public class P1531
{
    private int GetLength(int count)
    {
        if (count == 1)
            return 1;
        else if (count < 10)
            return 2;
        else if (count < 100)
            return 3;
        else
            return 4;
    }

    public int GetLengthOfOptimalCompression(string s, int k)
    {
        var n = s.Length;
        var dp = new int[n + 1, k + 1];

        for (int i = n; i >= 0; i--)
        {
            for (int j = 0; j <= k; j++)
            {
                if (i == n)
                {
                    dp[n, j] = 0;
                    continue;
                }

                dp[i, j] = (j > 0) 
                    ? dp[i + 1, j - 1] 
                    : int.MaxValue;

                var del = j;
                var count = 0;

                for (int l = i; l < n && del >= 0; l++)
                {
                    if (s[l] == s[i])
                    {
                        count++;
                        dp[i, j] = Math.Min(dp[i, j], GetLength(count) + dp[l + 1, del]);
                    }
                    else
                    {
                        del--;
                    }
                }
            }
        }

        return dp[0, k];
    }
}

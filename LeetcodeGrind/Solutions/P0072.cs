namespace LeetcodeGrind.Solutions;

// 72. Edit Distance
public class P0072
{
    public int MinDistance(string word1, string word2)
    {
        var rows = word1.Length;
        var cols = word2.Length;

        var dp = new int[rows + 1][];
        dp[0] = new int[cols + 1];
        for (int i = 1; i <= rows; i++)
        {
            dp[i] = new int[cols + 1];
            dp[i][0] = i;
        }

        for (int j = 1; j <= cols; j++)
            dp[0][j] = j;

        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= cols; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[i][j] = dp[i - 1][j - 1];
                }
                else
                {
                    var min = Math.Min(Math.Min(dp[i - 1][j],
                                                dp[i][j - 1]),
                                                dp[i - 1][j - 1]);
                    dp[i][j] = 1 + min;
                }
            }
        }

        return dp[^1][^1];
    }
}

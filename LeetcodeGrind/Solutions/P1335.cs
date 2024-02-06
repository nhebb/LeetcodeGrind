namespace LeetcodeGrind.Solutions;

// 1335. Minimum Difficulty of a Job Schedule
public class P1335
{
    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        if (jobDifficulty.Length < d)
        {
            return -1;
        }

        int n = jobDifficulty.Length;
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[d + 1];
            Array.Fill(dp[i], int.MaxValue);
        }

        int Dfs(int i, int day)
        {
            if (i >= jobDifficulty.Length && day == 0)
            {
                return 0;
            }

            if (i >= jobDifficulty.Length || day == 0)
            {
                return int.MaxValue / 2;
            }

            if (dp[i][day] != int.MaxValue)
            {
                return dp[i][day];
            }

            dp[i][day] = int.MaxValue / 2;
            int max = -1, j = i;

            while (j < jobDifficulty.Length)
            {
                max = Math.Max(max, jobDifficulty[j++]);
                dp[i][day] = Math.Min(dp[i][day], max + Dfs(j, day - 1));
            }

            return dp[i][day];
        }

        return Dfs(0, d);
    }
}

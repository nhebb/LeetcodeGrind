namespace LeetcodeGrind.Solutions;

// 1335. Minimum Difficulty of a Job Schedule
public class P1335
{
    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        if (d < jobDifficulty.Length)
        {
            return -1;
        }

        var n = jobDifficulty.Length;
        var dp = new int[n + 1][];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[d + 1];
            Array.Fill(dp[i], int.MaxValue);
        }

        void DPRecurse(int curJob, int curDay)
        {
            // Calculate the max number of days available starting
            // at the current job and current day
            // jobDifficulty = [1,2,3,4,5], d = 3
            // 
            var jobsLeft = n - curJob;      // 0-based
            var daysLeft = d - curDay + 1;  // 1-based
            if (jobsLeft < daysLeft)
            {
                return;
            }

            var availableJobs = jobsLeft - daysLeft + 1;

            for (int i = curJob; i < curJob + availableJobs - 1; i++)
            {

            }

        }

        DPRecurse(0, 1);

        return dp[0][d];
    }


    public int MinDifficulty2(int[] jobDifficulty, int d)
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

namespace LeetcodeGrind.Solutions;

// 1235. Maximum Profit in Job Scheduling
public class P1235
{
    private class Job
    {
        public int Start { get; init; }
        public int End { get; init; }
        public int Profit { get; init; }

        public Job(int start, int end, int profit)
        {
            Start = start;
            End = end;
            Profit = profit;
        }
    }

    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        var jobs = startTime
            .Select((_, i) => new Job(startTime[i], endTime[i], profit[i]))
            .OrderBy(j => j.Start)
            .ThenBy(j => j.End)
            .ToArray();

        var dp = new int[jobs.Length];
        Array.Fill(dp, -1);

        int BinSearchNextJob(int lastEnd)
        {
            int left = 0;
            int right = jobs.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (jobs[mid].Start >= lastEnd)
                    right = mid;
                else
                    left = mid + 1;
            }

            if (jobs[left].Start < lastEnd)
                return jobs.Length;

            return left;
        }

        int MaxProfitAtIndex(int index)
        {
            if (index == jobs.Length)
                return 0;

            if (dp[index] != -1)
                return dp[index];

            int nextJob = BinSearchNextJob(jobs[index].End);

            int max = jobs[index].Profit + MaxProfitAtIndex(nextJob);
            max = Math.Max(max, MaxProfitAtIndex(index + 1));

            dp[index] = max;
            return max;
        }

        return MaxProfitAtIndex(0);
    }
}

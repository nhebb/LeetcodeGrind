using System.Collections;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;

namespace LeetcodeGrind.Solutions;

// 826. Most Profit Assigning Work
public class P0826
{
    // My solution - slow
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
    {
        // Create a list of jobs sorted by difficulty, then by profit.
        var jobs = new List<(int Difficulty, int Profit)>();
        for (int i = 0; i < difficulty.Length; i++)
        {
            jobs.Add((difficulty[i], profit[i]));
        }

        var sorted = jobs.OrderBy(x => x.Difficulty)
                         .ThenBy(x => x.Profit)
                         .ToList();

        // Use binary search to find the job that has the max profit for
        // a difficulty less than or equal to the target (worker[i]).
        int GetMaxProfit(int target)
        {
            var left = 0;
            var right = sorted.Count;

            while (left < right)
            {
                int mid = (left + right) / 2;

                if (sorted[mid].Difficulty == target)
                {
                    left = mid + 1;
                }
                else if (sorted[mid].Difficulty <= target)
                {
                    left = mid + 1;
                }
                else if (sorted[mid].Difficulty > target)
                {
                    right = mid;
                }
            }

            var result = 0;
            // will exit out if target not found (e.g., left - 1 < 0)
            for (int i = 0; i <= left - 1; i++)
            {
                result = Math.Max(result, sorted[i].Profit);
            }

            return result;
        }

        var maxProfit = 0;
        foreach (var work in worker)
        {
            maxProfit += GetMaxProfit(work);
        }

        return maxProfit;
    }

    // My 2nd solution - faster
    public int MaxProfitAssignment2(int[] difficulty, int[] profit, int[] worker)
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < difficulty.Length; i++)
        {
            if (d.TryGetValue(difficulty[i], out int value))
                d[difficulty[i]] = Math.Max(value, profit[i]);
            else
                d[difficulty[i]] = profit[i];
        }

        var diff2 = new int[d.Count];
        var prof2 = new int[d.Count];
        int idx = 0;
        foreach (var kvp in d)
        {
            diff2[idx] = kvp.Key;
            prof2[idx] = kvp.Value;
            idx++;
        }

        Array.Sort(diff2, prof2);
        Array.Sort(worker);

        for (int i = 1; i < prof2.Length; i++)
        {
            prof2[i] = Math.Max(prof2[i - 1], prof2[i]);
        }

        // Use binary search to find the job that has the max profit for
        // a difficulty less than or equal to the target (worker[i]).
        int GetMaxProfit(int target)
        {
            var left = 0;
            var right = diff2.Length;

            while (left < right)
            {
                int mid = (left + right) / 2;

                if (diff2[mid] == target)
                {
                    return prof2[mid];
                }
                else if (diff2[mid] < target)
                {
                    left = mid + 1;
                }
                else if (diff2[mid] > target)
                {
                    right = mid;
                }
            }

            return left - 1 >= 0 
                ? prof2[left - 1] 
                : 0;
        }

        var maxProfit = 0;
        foreach (var work in worker)
        {
            maxProfit += GetMaxProfit(work);
        }

        return maxProfit;
    }

    // Faster solution - from LC's performance histogram
    public int MaxProfitAssignment3(int[] difficulty, int[] profit, int[] worker)
    {
        Array.Sort(worker);
        Array.Sort(difficulty, profit);

        int i = 0, j = 0, ans = 0;
        int max = 0;

        while (j < worker.Length)
        {
            if (i < difficulty.Length && worker[j] >= difficulty[i])
            {
                max = Math.Max(max, profit[i]);
                i++;
            }
            else
            {
                ans += max;
                j++;
            }
        }

        return ans;
    }
}

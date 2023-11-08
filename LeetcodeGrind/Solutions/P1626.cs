namespace LeetcodeGrind.Solutions;

// 1626. Best Team With No Conflicts
public class P1626
{
    public int BestTeamScore(int[] scores, int[] ages)
    {
        var n = scores.Length;

        // sort scores by age then score
        var scores2 = Enumerable.Range(0, n)
                                .OrderBy(x => ages[x])
                                .ThenBy(x => scores[x])
                                .Select(x => scores[x])
                                .ToArray();

        int[] dp = new int[n];
        dp[^1] = scores2[^1];

        for (int i = n - 2; i >= 0; i--)
        {
            // Find the higher scores to the right of the current
            // score, select their dp[] values, and add the max
            // one to the current score
            dp[i] = scores2[i] +
                    Enumerable.Range(i + 1, n - i - 1)
                              .Where(x => scores2[x] >= scores2[i])
                              .Select(x => dp[x])
                              .DefaultIfEmpty(0)
                              .Max();
        }

        // return the highest team score in the dp tabulation
        return dp.Max();
    }
}

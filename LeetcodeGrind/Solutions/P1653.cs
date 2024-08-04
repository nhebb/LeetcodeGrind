namespace LeetcodeGrind.Solutions;

// 1653. Minimum Deletions to Make String Balanced
public class P1653
{
    // Source: https://leetcode.com/problems/minimum-deletions-to-make-string-balanced/solutions/935701/dp-solution-beats-100-with-explanation/?envType=daily-question&envId=2024-07-30
    public int MinimumDeletions(string s)
    {
        // dp stores number of chars to remove to make s.Substring(0, i) valid
        var dp = new int[s.Length + 1];
        var bCount = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'a')
            {
                // Case 1: Keep the current 'a' if all previous characters
                // are 'a', and therefore remove all 'b' chars before i,
                // which is bCount.

                // Case 2: Remove current a if previous characters include a 'b'.
                dp[i + 1] = Math.Min(dp[i] + 1, bCount);
            }
            else
            {
                // It's always valid to append 'b', so just copy dp[i];
                dp[i + 1] = dp[i];
                bCount++;
            }
        }

        return dp[^1];
    }
}

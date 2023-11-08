namespace LeetcodeGrind.Solutions;

// 2009. Minimum Number of Operations to Make Array Continuous
public class P2009
{
    public int MinOperations2(int[] nums)
    {
        var unique = nums.ToHashSet().OrderBy(x => x).ToArray();
        var len = nums.Length;
        var ans = len;

        int j = 0;
        for (int i = 0; i < unique.Length; i++)
        {
            // j is essentially counting the number of items
            // that need to change to be continuous.
            while (j < unique.Length
                && unique[j] < unique[i] + len)
            {
                j++;
            }

            int diff = j - i;

            // take min in case incrementing goes past length needed.
            ans = Math.Min(ans, len - diff);
        }

        return ans;
    }
}

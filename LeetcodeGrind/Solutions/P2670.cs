namespace LeetcodeGrind.Solutions;

// 2670. Find the Distinct Difference Array
public class P2670
{
    public int[] DistinctDifferenceArray(int[] nums)
    {
        var n = nums.Length;

        var hsRight = new HashSet<int>(n);
        var suffix = new int[n + 1];
        suffix[^1] = 0;
        for (int i = suffix.Length - 2; i >= 0; i--)
        {
            hsRight.Add(nums[i]);
            suffix[i] = hsRight.Count;
        }

        var hsLeft = new HashSet<int>(n);
        var ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            hsLeft.Add(nums[i]);
            ans[i] = hsLeft.Count - suffix[i + 1];
        }

        return ans;
    }
}

namespace LeetcodeGrind.Solutions;

// 1929. Concatenation of Array
public class P1929
{
    public int[] GetConcatenation(int[] nums)
    {
        var n = nums.Length;
        var ans = new int[n * 2];

        // slowest
        //Array.Copy(nums, 0, ans, 0, n);
        //Array.Copy(nums, 0, ans, n, n);

        // slower
        //nums.CopyTo(ans, 0);
        //nums.CopyTo(ans, n);

        // faster
        for (int i = 0; i < n; i++)
        {
            ans[i] = nums[i];
            ans[i + n] = nums[i];
        }
        return ans;
    }
}

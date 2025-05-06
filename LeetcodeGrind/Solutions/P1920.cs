namespace LeetcodeGrind.Solutions;

// 1920. Build Array from Permutation
public class P1920
{
    public int[] BuildArray(int[] nums)
    {
        var ans = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            ans[i] = nums[nums[i]];
        }

        return ans;
    }
}

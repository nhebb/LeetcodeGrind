namespace LeetcodeGrind.Solutions;

// 268. Missing Number
public class P0268
{
    public int MissingNumber(int[] nums)
    {
        int result = 0;
        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            result += (i - nums[i]);
        }

        result += n;

        return result;
    }
}

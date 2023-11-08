namespace LeetcodeGrind.Solutions;

// 713. Subarray Product Less Than K
// TODO: Finish this. Wrong Answer.
public class P0713
{
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        int count = 0;
        int q = 0;
        int product = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            // 1. Calculate product
            product *= nums[i];

            // 2. While the product is > target, increase left.
            while (product >= k && q < i)
            {
                product /= nums[q];
                q++;
            }
        }
        return count;
    }
}

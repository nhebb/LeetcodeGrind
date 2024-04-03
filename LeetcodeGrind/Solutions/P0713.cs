namespace LeetcodeGrind.Solutions;

// TODO: 713. Subarray Product Less Than K
// This solution fails with Wrong Answer.
public class P0713
{
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1) 
            return 0;

        int count = 0;
        int product = 1;
        int i = 0;

        for (int j = 0; j < nums.Length; j++)
        {
            product *= nums[j];

            while (product >= k && i <= j)
            {
                product /= nums[i];
                i++;
            }

            count += j - i + 1; 
        }

        return count;
    }
}

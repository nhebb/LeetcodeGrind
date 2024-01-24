namespace LeetcodeGrind.Solutions;

// 152. Maximum Product Subarray
public class P0152
{
    public int MaxProduct(int[] nums)
    {
        int maxProduct = nums[0];
        int currentMax = maxProduct;
        int currentMin = maxProduct;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < 0)
            {
                // Swap max and min in case min is a negative number,
                // making the product a positive number
                (currentMax, currentMin) = (currentMin, currentMax);
            }

            currentMax = Math.Max(currentMax * nums[i], nums[i]);
            currentMin = Math.Min(currentMin * nums[i], nums[i]);

            maxProduct = Math.Max(maxProduct, currentMax);
        }

        return maxProduct;
    }
}

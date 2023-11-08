namespace LeetcodeGrind.Solutions;

// 238. Product of Array Except Self
public class P0238
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var products = new int[nums.Length];

        // special cases
        if (nums.Length == 1)
        {
            products[0] = 0;
            return products;
        }
        else if (nums.Length == 2)
        {
            products[0] = nums[1];
            products[1] = nums[0];
            return products;
        }
        else if (nums.Where(x => x == 0).Count() > 1)
        {
            return products;
        }

        // prefix products
        var prefixes = new int[nums.Length];
        prefixes[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            prefixes[i] = prefixes[i - 1] * nums[i];
        }

        var suffixes = new int[nums.Length];
        suffixes[^1] = nums[^1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            suffixes[i] = suffixes[i + 1] * nums[i];
        }

        for (int i = 1; i < nums.Length - 1; i++)
        {
            products[i] = prefixes[i - 1] * suffixes[i + 1];
        }
        products[0] = suffixes[1];
        products[^1] = prefixes[^2];

        return products;
    }
}

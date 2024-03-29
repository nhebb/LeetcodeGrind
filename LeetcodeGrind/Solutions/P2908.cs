namespace LeetcodeGrind.Solutions;

// 2908. Minimum Sum of Mountain Triplets I
public class P2908
{
    public int MinimumSum(int[] nums)
    {
        var min = int.MaxValue;
        var prefixMin = new int[nums.Length];
        var suffixMin = new int[nums.Length];

        prefixMin[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            prefixMin[i] = Math.Min(prefixMin[i - 1], nums[i]);
        }

        suffixMin[^1] = nums[^1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            suffixMin[i] = Math.Min(suffixMin[i + 1], nums[i]);
        }


        for (int i = 1; i < nums.Length - 1; i++)
        {
            if (prefixMin[i - 1] < nums[i] && nums[i] > suffixMin[i + 1])
            {
                var sum = prefixMin[i - 1] + nums[i] + suffixMin[i + 1];
                min = Math.Min(min, sum);
            }
        }

        return min == int.MaxValue ? -1 : min;
    }
}

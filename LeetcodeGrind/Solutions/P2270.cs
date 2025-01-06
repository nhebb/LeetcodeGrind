namespace LeetcodeGrind.Solutions;

// 2270. Number of Ways to Split Array
public class P2270
{
    public int WaysToSplitArray(int[] nums)
    {
        var prefix = new long[nums.Length];
        var suffix = new long[nums.Length];

        prefix[0] = nums[0];
        suffix[^1] = nums[^1];

        for (int i = 1; i < nums.Length; i++)
        {
            prefix[i] = prefix[i - 1] + nums[i];
        }

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            suffix[i] = suffix[i + 1] + nums[i];
        }

        var count = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (prefix[i] >= suffix[i + 1])
            {
                count++;
            }
        }

        return count;
    }
}

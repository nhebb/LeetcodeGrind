namespace LeetcodeGrind.Solutions;

// TODO: 2967. Minimum Cost to Make Array Equalindromic
public class P2967
{
    public long MinimumCost(int[] nums)
    {
        Array.Sort(nums);
        var median = nums.Length % 2 == 1
            ? nums[nums.Length / 2]
            : (nums[nums.Length / 2] + nums[(nums.Length + 1) / 2]) / 2;
        var medianStr = median.ToString().ToCharArray();
        int a = 0;
        int b = medianStr.Length - 1;
        while (a < b)
        {
            medianStr[b] = medianStr[a];
            a++;
            b--;
        }

        var target = 0;
        for (int i = 0; i < medianStr.Length; i++)
        {
            target *= 10;
            target += medianStr[i] - '0';
        }

        long cost = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            cost += Math.Abs(nums[i] - target);
        }

        return cost;
    }
}

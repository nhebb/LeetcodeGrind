namespace LeetcodeGrind.Solutions;

// 3068. Find the Maximum Sum of Node Values
public class P3068
{
    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        var maxSum = 0L;
        var diff = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            diff[i] = (nums[i] ^ k) - nums[i];
            maxSum += nums[i];
        }

        Array.Sort(diff, (a, b) => b.CompareTo(a));

        for (int i = 0; i < nums.Length - 1; i += 2)
        {
            long sum = diff[i] + diff[i + 1];

            if (sum <= 0)
            {
                break;
            }

            maxSum += sum;
        }

        return maxSum;
    }
}

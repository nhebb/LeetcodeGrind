namespace LeetcodeGrind.Solutions;

// 2357. Make Array Zero by Subtracting Equal Amounts
public class P2357
{
    public int MinimumOperations(int[] nums)
    {
        Array.Sort(nums);

        var lastVal = 0;
        var count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == lastVal)
            {
                continue;
            }

            count++;
            lastVal = nums[i];
        }

        return count;
    }
}

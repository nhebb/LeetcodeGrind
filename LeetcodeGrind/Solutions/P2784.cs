namespace LeetcodeGrind.Solutions;

// 2784. Check if Array is Good
public class P2784
{
    public bool IsGood(int[] nums)
    {
        if (nums.Length == 1)
        {
            return false;
        }

        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] != i + 1)
            {
                return false;
            }
        }

        return nums[^1] == nums[^2];
    }
}

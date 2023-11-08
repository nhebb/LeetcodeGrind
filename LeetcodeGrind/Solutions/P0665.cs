namespace LeetcodeGrind.Solutions;

// 665. Non-decreasing Array
// TODO: This fails test case { 3,4,2,3 }
public class P0665
{
    public bool CheckPossibility(int[] nums)
    {
        var changed = false;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] <= nums[i + 1])
                continue;

            if (changed)
                return false;

            if (i == 0 || nums[i + 1] >= nums[i - 1])
                nums[i] = nums[i + 1];
            else
                nums[i + 1] = nums[i];

            changed = true;
        }
        return true;
    }
}

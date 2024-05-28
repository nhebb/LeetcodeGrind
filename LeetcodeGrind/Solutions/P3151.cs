namespace LeetcodeGrind.Solutions;

// 3151. Special Array I
public class P3151
{
    public bool IsArraySpecial(int[] nums)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] % 2 == nums[i + 1] % 2)
            {
                return false;
            }
        }

        return true;
    }
}

namespace LeetcodeGrind.Solutions;

// 55. Jump Game
public class P0055
{
    public bool CanJump(int[] nums)
    {
        var target = nums.Length - 1;

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (i + nums[i] >= target)
                target = i;
        }

        return target == 0;
    }
}

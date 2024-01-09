namespace LeetcodeGrind.Solutions;

// 2293. Min Max Game
public class P2293
{
    public int MinMaxGame(int[] nums)
    {
        var len = nums.Length / 2;

        while (len > 0)
        {
            for (int i = 0; i < len; i++)
            {
                if (i % 2 == 0)
                {
                    nums[i] = Math.Min(nums[i * 2], nums[i * 2 + 1]);
                }
                else
                {
                    nums[i] = Math.Max(nums[i * 2], nums[i * 2 + 1]);
                }
            }
            len /= 2;
        }

        return nums[0];
    }
}

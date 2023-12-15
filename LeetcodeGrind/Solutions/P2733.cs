using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2733. Neither Minimum nor Maximum
public class P2733
{
    public int FindNonMinOrMax(int[] nums)
    {
        var min = nums.Min();
        var max = nums.Max();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != min && nums[i] != max)
            {
                return nums[i];
            }
        }

        return -1;
    }
}

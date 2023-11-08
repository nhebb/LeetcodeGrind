namespace LeetcodeGrind.Solutions;

// 747. Largest Number At Least Twice of Others
public class P0747
{
    public int DominantIndex(int[] nums)
    {
        var max = int.MinValue;
        var maxIndex = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max)
            {
                max = nums[i];
                maxIndex = i;
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] * 2 > max)
            {
                return -1;
            }
        }
        return maxIndex;
    }
}

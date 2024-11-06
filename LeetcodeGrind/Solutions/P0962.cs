namespace LeetcodeGrind.Solutions;

// TODO: 962. Maximum Width Ramp
public class P0962
{
    public int MaxWidthRamp(int[] nums)
    {
        // totally wrong approach
        var rightMax = new int[nums.Length];
        rightMax[^1] = nums[^1];

        for (int k = nums.Length - 2; k >= 0; k--)
        {
            rightMax[k] = Math.Max(rightMax[k + 1], nums[k]);
        }

        var i = 0;
        var j = 0;
        var max = 0;

        while (j < nums.Length)
        {
            while (i < j && nums[i] > rightMax[j])
            {
                i++;
            }

            max = Math.Max(max, j - i);
            j++;
        }

        return max;
    }
}

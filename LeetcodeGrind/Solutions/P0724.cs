namespace LeetcodeGrind.Solutions;

// 724. Find Pivot Index
public class P0724
{
    public int PivotIndex(int[] nums)
    {
        int rsum = nums.Sum();
        if (rsum - nums[0] == 0)
        {
            return 0;
        }

        int lsum = nums[0];
        rsum -= nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            rsum -= nums[i];
            if (lsum == rsum)
            {
                return i;
            }
            lsum += nums[i];
        }
        return -1;
    }
}

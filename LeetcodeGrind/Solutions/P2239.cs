namespace LeetcodeGrind.Solutions;

// 2239. Find Closest Number to Zero
public class P2239
{
    public int FindClosestNumber(int[] nums)
    {
        var minVal = int.MinValue;
        var minAbs = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            var diff = Math.Abs(nums[i] - 0);
            if (diff < minAbs)
            {
                minAbs = diff;
                minVal = nums[i];
            }
            else if (diff == minAbs)
            {
                minVal = Math.Max(minVal, nums[i]);
            }
        }

        return minVal;
    }
}

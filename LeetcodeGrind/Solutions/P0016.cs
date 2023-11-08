namespace LeetcodeGrind.Solutions;

// 16. 3Sum Closest
public class P0016
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);

        var minDiff = int.MaxValue;
        var minSum = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            var lastDiff = int.MaxValue;
            int j = i + 1;
            int k = nums.Length - 1;
            while (j < k)
            {
                var diff = nums[i] + nums[j] + nums[k] - target;
                if (diff == 0)
                    return nums[i] + nums[j] + nums[k];

                var absDiff = Math.Abs(diff);
                if (absDiff < minDiff)
                {
                    minDiff = absDiff;
                    minSum = nums[i] + nums[j] + nums[k];
                }

                lastDiff = absDiff;

                if (diff < 0)
                    j++;
                else if (diff > 0)
                    k--;
            }
        }
        return minSum;
    }
}

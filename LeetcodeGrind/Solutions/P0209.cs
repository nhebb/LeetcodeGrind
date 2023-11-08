namespace LeetcodeGrind.Solutions;

// 
public class P0209
{
    // 209. Minimum Size Subarray Sum
    public int MinSubArrayLen(int target, int[] nums)
    {
        if (nums.Length == 1 && nums[0] < target)
            return 0;

        var min = nums.Length + 1;

        var i = 0;
        var j = 0;
        var sum = 0;
        // nums = [2,3,1,2,4,3] target = 7
        while (j < nums.Length)
        {
            sum += nums[j];
            if (sum >= target)
            {
                // 1, 5 = 10
                //min = Math.Min(min, j - i + 1);
                while (i <= j && sum >= target)
                {
                    min = Math.Min(min, j - i + 1);
                    sum -= nums[i];
                    i++;
                }
            }
            j++;
        }

        if (min > nums.Length)
            return 0;
        return min;
    }
}

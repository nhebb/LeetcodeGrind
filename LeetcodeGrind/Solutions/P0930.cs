namespace LeetcodeGrind.Solutions;

// 930. Binary Subarrays With Sum
public class P0930
{
    public int NumSubarraysWithSum(int[] nums, int goal)
    {
        // brute force - barey passes time limit
        if (nums.Length == 1)
        {
            return nums[0] == goal
                ? 1
                : 0;
        }

        var count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            var prev = 0;
            for (int j = i; j < nums.Length; j++)
            {
                var curr = prev + nums[j];
                if (curr > goal)
                {
                    break;
                }

                if (curr == goal)
                {
                    count++;
                }
                prev = curr;
            }
        }

        return count;
    }
}

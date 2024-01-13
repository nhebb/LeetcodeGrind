namespace LeetcodeGrind.Solutions;

// 2996. Smallest Missing Integer Greater Than Sequential Prefix Sum
public class P2996
{
    public int MissingInteger(int[] nums)
    {
        var hs = nums.ToHashSet();
        var sum = nums[0];

        var i = 1;
        while (i < nums.Length)
        {
            if (nums[i] == nums[i - 1] + 1)
            {
                sum += nums[i];
            }
            else
            {
                // Only count the sequence starting at index 0.
                // Whoever wrote this problem description is a
                // major dick. :-)
                break; 
            }
            i++;
        }

        var result = sum;
        while (hs.Contains(result))
            result++;

        return result;
    }
}

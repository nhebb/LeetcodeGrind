namespace LeetcodeGrind.Solutions;

// 3038. Maximum Number of Operations With the Same Score I
public class P3038
{
    public int MaxOperations(int[] nums)
    {
        var sum = nums[0] + nums[1];
        var count = 1;

        for (int i = 2; i < nums.Length - 1; i += 2)
        {
            if (nums[i] + nums[i + 1] == sum)
                count++;
            else
                break;
        }

        return count;
    }
}

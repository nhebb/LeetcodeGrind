namespace LeetcodeGrind.Solutions;

// 2460. Apply Operations to an Array
public class P2460
{
    public int[] ApplyOperations(int[] nums)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == nums[i + 1])
            {
                nums[i] *= 2;
                nums[i + 1] = 0;
            }
        }

        var result = new int[nums.Length];
        int j = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                result[j] = nums[i];
                j++;
            }
        }

        return result;
    }
}

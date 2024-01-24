namespace LeetcodeGrind.Solutions;

// 645. Set Mismatch
public class P0645
{
    public int[] FindErrorNums(int[] nums)
    {
        var result = new int[2];
        var hs = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!hs.Add(nums[i]))
                result[0] = nums[i];
        }
        for (int i = 1; i <= nums.Length; i++)
        {
            if (!hs.Contains(i))
            {
                result[1] = i;
                break;
            }
        }
        return result;
    }
}

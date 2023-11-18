namespace LeetcodeGrind.Solutions;

// 1877. Minimize Maximum Pair Sum in Array
public class P1877
{
    public int MinPairSum(int[] nums)
    {
        Array.Sort(nums);
        int max = int.MinValue;
        int i = 0;
        int j = nums.Length - 1;
        while (i < j)
        {
            max = Math.Max(max, nums[i] + nums[j]);
            i++;
            j--;
        }
        return max;
    }
}

namespace LeetcodeGrind.Solutions;

// 2221. Find Triangular Sum of an Array
public class P2221
{
    public int TriangularSum(int[] nums)
    {
        var last = nums.Length - 1;
        while (last > 0)
        {
            for (int i = 0; i < last; i++)
            {
                nums[i] = (nums[i] + nums[i + 1]) % 10;
            }
            last--;
        }
        return nums[0];
    }
}

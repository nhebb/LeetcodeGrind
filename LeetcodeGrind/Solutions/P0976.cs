namespace LeetcodeGrind.Solutions;

// 976. Largest Perimeter Triangle
public class P0976
{
    public int LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);

        var i = nums.Length - 1;
        while (i >= 2)
        {
            if (nums[i] >= nums[i - 1] + nums[i - 2])
            {
                i--;
            }
            else
            {
                return nums[i] + nums[i - 1] + nums[i - 2];
            }
        }

        return 0;
    }
}

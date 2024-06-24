namespace LeetcodeGrind.Solutions;

// 3194. Minimum Average of Smallest and Largest Elements
public class P3194
{
    public double MinimumAverage(int[] nums)
    {
        Array.Sort(nums);

        var min = double.MaxValue;
        var i = 0;
        var j = nums.Length - 1;

        while (i <= j)
        {
            var value = (nums[i] + nums[j]) / 2.0;
            min = Math.Min(min, value);
            i++;
            j--;
        }

        return min;
    }
}

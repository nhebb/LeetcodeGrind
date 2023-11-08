namespace LeetcodeGrind.Solutions;

// 162. Find Peak Element
public class P0162
{
    public int FindPeakElement(int[] nums)
    {
        if (nums.Length == 1) return 0;
        if (nums[0] > nums[1]) return 0;
        if (nums[^1] > nums[^2]) return nums.Length - 1;

        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid - 1] < nums[mid] && nums[mid] > nums[mid + 1])
                return mid;
            else if (nums[mid] < nums[mid + 1])
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }
}

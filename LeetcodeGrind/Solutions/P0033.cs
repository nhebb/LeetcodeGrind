namespace LeetcodeGrind.Solutions;

// 33. Search in Rotated Sorted Array
public class P0033
{
    public int Search(int[] nums, int target)
    {
        if (nums == null)
            return -1;

        if (nums.Length == 1)
            return nums[0] == target ? 0 : -1;

        int i = 0;
        int j = nums.Length - 1;
        int mid = (i + j) / 2;
        while (i < j)
        {
            if (nums[mid] == target)
                return mid;

            if (
                   (nums[i] > nums[mid] && (nums[i] <= target || target <= nums[mid]))
                || (nums[i] < nums[mid] && (nums[i] <= target && target <= nums[mid]))
               )
                j = mid - 1;
            else if (mid < nums.Length - 1)
                i = mid + 1;
            else
                break;

            mid = (i + j) / 2;
            if (nums[mid] == target)
                return mid;
        }
        return -1;
    }
}

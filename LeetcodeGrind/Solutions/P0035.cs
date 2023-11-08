namespace LeetcodeGrind.Solutions;

// 35. Search Insert Position
public class P0035
{
    public int SearchInsert(int[] nums, int target)
    {
        if (target < nums[0])
            return 0;
        if (target > nums[^1])
            return nums.Length;

        int BinSearch(int idx1, int idx2)
        {
            var mid = idx1 + (idx2 - idx1) / 2;

            if (nums[mid] == target)
                return mid;

            // edge cases at each end of array
            if (mid == 0)
                return target < nums[0] ? 0 : 1;

            if (mid == nums.Length - 1)
                return target < nums[^1] ? nums.Length - 1 : nums.Length;

            // check left neighbor
            if (mid > 0 && target > nums[mid - 1] && target < nums[mid])
                return mid;

            // check right neighbor
            if (mid < nums.Length - 1 && target > nums[mid] && target < nums[mid + 1])
                return mid + 1;

            // continue search
            if (target < nums[mid])
                return BinSearch(idx1, mid - 1);
            else
                return BinSearch(mid + 1, idx2);
        }
        return BinSearch(0, nums.Length - 1);
    }
}

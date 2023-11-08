namespace LeetcodeGrind.Solutions;

// 34. Find First and Last Position of Element in Sorted Array
public class P0034
{
    public int[] SearchRange(int[] nums, int target)
    {
        var first = nums.Length;
        var last = -1;

        void FindMinMax(int idx1, int idx2)
        {
            if (idx2 < idx1) return;

            var searchMin = false;
            var searchMax = false;
            var mid = idx1 + (idx2 - idx1) / 2;
            if (nums[mid] == target)
            {
                first = Math.Min(first, mid);
                last = Math.Max(last, mid);

                searchMin = mid > 0 && nums[mid - 1] == target;
                searchMax = mid < nums.Length - 1 && nums[mid + 1] == target;
            }

            if (searchMin || nums[mid] > target)
            {
                FindMinMax(idx1, mid - 1);
            }

            if (searchMax || nums[mid] < target)
            {
                FindMinMax(mid + 1, idx2);
            }
        }

        FindMinMax(0, nums.Length - 1);

        if (last == -1 || first == nums.Length)
            return new int[] { -1, -1 };

        return new int[] { first, last };
    }
}

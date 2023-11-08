namespace LeetcodeGrind.Solutions;

// 875. Koko Eating Bananas
public class P0875
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        var lo = 1;
        var hi = piles.Max();
        var result = hi;

        while (lo < hi)
        {
            var mid = lo + (hi - lo) / 2;
            var hours = 0;

            foreach (var pile in piles)
                hours += (int)Math.Ceiling(pile / (double)mid);

            if (hours <= h)
            {
                result = Math.Min(result, mid);
                hi = mid;
            }
            else
            {
                lo = mid + 1;
            }
        }

        return result;
    }


    // 540. Single Element in a Sorted Array
    // O(n) approach
    public int SingleNonDuplicate(int[] nums)
    {
        var xor = 0;
        foreach (var num in nums)
            xor ^= num;
        return xor;
    }
    // O(log n) recursive binary search approach
    public int SingleNonDuplicate2(int[] nums)
    {
        int BinSearch(int lo, int hi)
        {
            var mid = lo + (hi - lo) / 2;
            if (mid == 0 || mid == nums.Length - 1)
                return nums[mid];

            if (nums[mid] != nums[mid - 1] && nums[mid] != nums[mid + 1])
                return nums[mid];

            if (mid % 2 == 1)
            {
                if (nums[mid] == nums[mid - 1])
                    return BinSearch(mid + 1, hi);
                else
                    return BinSearch(lo, mid - 1);
            }
            else
            {
                if (nums[mid] == nums[mid + 1])
                    return BinSearch(mid + 2, hi);
                else
                    return BinSearch(lo, mid - 2);
            }
        }

        return BinSearch(0, nums.Length - 1);
    }

    // Fastest: O(log n) non-recursive binary search approach
    public int SingleNonDuplicate3(int[] nums)
    {
        var lo = 0;
        var hi = nums.Length - 1;
        while (lo < hi)
        {
            var mid = lo + (hi - lo) / 2;
            if (mid == 0 || mid == nums.Length - 1)
                return nums[mid];

            if (nums[mid] != nums[mid - 1] && nums[mid] != nums[mid + 1])
                return nums[mid];

            if (mid % 2 == 1)
            {
                if (nums[mid] == nums[mid - 1])
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }
            else
            {
                if (nums[mid] == nums[mid + 1])
                    lo = mid + 2;
                else
                    hi = mid - 2;
            }
        }

        return nums[lo];
    }
}


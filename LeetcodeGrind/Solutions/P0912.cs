namespace LeetcodeGrind.Solutions;

// 912. Sort an Array
public class P0912
{
    public int[] SortArray(int[] nums)
    {
        void Quicksort(int lo, int hi)
        {
            if (lo < hi)
            {
                var p = Partition(lo, hi);
                Quicksort(lo, p - 1);
                Quicksort(p + 1, hi);
            }
        }

        int Partition(int lo, int hi)
        {
            var pivot = nums[hi];
            var i = lo;

            for (int j = lo; j <= hi - 1; j++)
            {
                if (nums[j] <= pivot)
                {
                    i++;
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }

            i++;
            (nums[i], nums[hi]) = (nums[hi], nums[i]);

            return i;
        }

        Quicksort(0, nums.Length - 1);
        return nums;
    }
}

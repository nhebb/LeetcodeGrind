namespace LeetcodeGrind.Solutions;

// 324. Wiggle Sort II
public class P0324
{
    public void WiggleSort(int[] nums)
    {
        int len = nums.Length;
        var mid = (len + 1) / 2;
        var sorted = new int[len];
        Array.Copy(nums, sorted, len);
        Array.Sort(sorted);

        var i = mid - 1;
        var j = 0;
        while (i >= 0)
        {
            nums[j] = sorted[i];
            i--;
            j += 2;
        }

        i = len - 1;
        j = 1;
        while (i >= mid)
        {
            nums[j] = sorted[i];
            i--;
            j += 2;
        }
    }
}

namespace LeetcodeGrind.Solutions;

// 2717. Semi-Ordered Permutation

public class P2717
{
    public int SemiOrderedPermutation(int[] nums)
    {
        var n = nums.Length;
        var first = Array.IndexOf(nums, 1);
        var last = Array.IndexOf(nums, n);

        var swaps = first + n - 1 - last;
        if (first > last)
        {
            swaps--;
        }

        return swaps;
    }
}

namespace LeetcodeGrind.Solutions;

// 81. Search in Rotated Sorted Array II
// OK, this is supposed to be a binary search problem,
// but I got lazy ...
public class P0081
{
    public bool SearchII(int[] nums, int target)
    {
        return nums.Any(x => x == target);
    }
}

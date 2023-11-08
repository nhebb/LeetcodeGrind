namespace LeetcodeGrind.Solutions;

// 2540. Minimum Common Value
public class P2540
{
    public int GetCommon(int[] nums1, int[] nums2)
    {
        var both = nums1.Intersect(nums2);
        if (both.Count() == 0)
            return -1;
        return both.Min();
    }
}

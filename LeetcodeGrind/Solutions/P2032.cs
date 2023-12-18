namespace LeetcodeGrind.Solutions;

// 2032. Two Out of Three
public class P2032
{
    public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
    {
        var intersected = nums1.Intersect(nums2).ToList();
        intersected.AddRange(nums1.Intersect(nums3));
        intersected.AddRange(nums2.Intersect(nums3));
        return intersected.Distinct().ToList();
    }
}

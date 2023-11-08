namespace LeetcodeGrind.Solutions;

// 2215. Find the Difference of Two Arrays
public class P2215
{
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        var ans = new List<IList<int>>();

        ans.Add(nums1.Except(nums2).Distinct().ToList());
        ans.Add(nums2.Except(nums1).Distinct().ToList());

        return ans;
    }
}

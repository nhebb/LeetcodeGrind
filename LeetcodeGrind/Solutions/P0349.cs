namespace LeetcodeGrind.Solutions;

// 349. Intersection of Two Arrays
public class P0349
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var hs1 = new HashSet<int>();
        var hs2 = new HashSet<int>();

        foreach (var num in nums1)
            hs1.Add(num);
        foreach (var num in nums2)
            hs2.Add(num);

        var ans = new List<int>();
        foreach (var num in hs1)
            if (hs2.Contains(num))
                ans.Add(num);

        return ans.ToArray();
    }
}

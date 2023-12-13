namespace LeetcodeGrind.Solutions;

// 2956. Find Common Elements Between Two Arrays
public class P2956
{
    public int[] FindIntersectionValues(int[] nums1, int[] nums2)
    {
        var hs1 = nums1.ToHashSet();
        var hs2 = nums2.ToHashSet();

        var count1 = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            if (hs2.Contains(nums1[i]))
            {
                count1++;
            }
        }

        var count2 = 0;
        for (int i = 0; i < nums2.Length; i++)
        {
            if (hs1.Contains(nums2[i]))
            {
                count2++;
            }
        }

        return new int[] { count1, count2 };
    }
}

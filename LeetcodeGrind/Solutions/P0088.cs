namespace LeetcodeGrind.Solutions;

// 88. Merge Sorted Array
public class P0088
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        if (n == 0) return;
        if (m == 0)
        {
            nums2.CopyTo(nums1, 0);
            return;
        }

        var j = m - 1;
        var k = n - 1;
        for (int i = m + n - 1; i >= 0 && j >= 0 && k >= 0; i--)
        {
            if (nums1[j] > nums2[k])
            {
                nums1[i] = nums1[j];
                j--;
            }
            else
            {
                nums1[i] = nums2[k];
                k--;
            }
        }

        while (k >= 0)
        {
            nums1[k] = nums2[k];
            k--;
        }
    }
}

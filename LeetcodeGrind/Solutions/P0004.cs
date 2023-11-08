namespace LeetcodeGrind.Solutions;

// 4. Median of Two Sorted Arrays
public class P0004
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var idx1 = 0;
        var idx2 = 0;
        var len1 = nums1.Length;
        var len2 = nums2.Length;
        var totalLen = len1 + len2;
        var isEven = (totalLen % 2 == 0);
        var lastIndex = totalLen / 2;

        var allNums = new List<int>(totalLen);

        while (idx1 < len1 && idx2 < len2 && (idx1 + idx2 <= lastIndex))
        {
            if (nums1[idx1] <= nums2[idx2])
            {
                allNums.Add(nums1[idx1]);
                idx1++;
            }
            else
            {
                allNums.Add(nums2[idx2]);
                idx2++;
            }
        }
        while (idx1 < len1 && (idx1 + idx2 <= lastIndex))
        {
            allNums.Add(nums1[idx1]);
            idx1++;
        }
        while (idx2 < len2 && (idx1 + idx2 <= lastIndex))
        {
            allNums.Add(nums2[idx2]);
            idx2++;
        }

        double medium = isEven
            ? (allNums[lastIndex - 1] / 2.0) + (allNums[lastIndex] / 2.0)
            : allNums[lastIndex];

        return medium;
    }
}

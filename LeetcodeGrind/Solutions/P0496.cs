namespace LeetcodeGrind.Solutions;

// 496. Next Greater Element I
public class P0496
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < nums2.Length; i++)
        {
            d[nums2[i]] = i;
        }

        var ans = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            var found = false;
            int j = d[nums1[i]] + 1;
            while (j < nums2.Length)
            {
                if (nums2[j] > nums1[i])
                {
                    ans[i] = nums2[j];
                    found = true;
                    break;
                }
                j++;
            }
            if (!found)
                ans[i] = -1;
        }
        return ans;
    }
}

namespace LeetcodeGrind.Solutions;

// 2605. Form Smallest Number From Two Digit Arrays
public class P2605
{
    public int MinNumber(int[] nums1, int[] nums2)
    {
        var has1 = new bool[10];
        var has2 = new bool[10];

        foreach (var num in nums1)
        {
            has1[num] = true;
        }
        foreach (var num in nums2)
        {
            has2[num] = true;
        }

        var min1 = nums1[0];
        var min2 = nums2[0];
        for (int i = 0; i < 10; i++)
        {
            if (has1[i] && has2[i])
            {
                return i;
            }

            if (has1[i] && i < min1)
                min1 = i;

            if (has2[i] && i < min2)
                min2 = i;
        }

        if (min1 < min2)
            return 10 * min1 + min2;

        return 10 * min2 + min1;
    }
}

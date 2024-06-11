namespace LeetcodeGrind.Solutions;

// 3162. Find the Number of Good Pairs I
public class P3162
{
    public int NumberOfPairs(int[] nums1, int[] nums2, int k)
    {
        var count = 0;

        foreach (var num1 in nums1)
        {
            foreach (var num2 in nums2)
            {
                if (num1 % (num2 * k) == 0)
                {
                    count++;
                }
            }
        }

        return count;
    }
}

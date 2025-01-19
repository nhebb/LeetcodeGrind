namespace LeetcodeGrind.Solutions;

// 2425. Bitwise XOR of All Pairings
public class P2425
{
    public int XorAllNums(int[] nums1, int[] nums2)
    {
        var isOdd1 = nums2.Length % 2 == 1;
        var isOdd2 = nums1.Length % 2 == 1;
        var xor = 0;

        if (isOdd1)
        {
            foreach (var num in nums1)
            {
                xor ^= num;
            }
        }
        if (isOdd2)
        {
            foreach (var num in nums2)
            {
                xor ^= num;
            }
        }

        return xor;
    }
}

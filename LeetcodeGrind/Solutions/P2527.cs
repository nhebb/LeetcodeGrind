namespace LeetcodeGrind.Solutions;

// 2527. Find Xor-Beauty of Array
public class P2527
{
    public int XorBeauty(int[] nums)
    {
        // the trick is that you just XOR all the values
        var ans = 0;
        foreach (var num in nums)
            ans ^= num;
        return ans;
    }
}

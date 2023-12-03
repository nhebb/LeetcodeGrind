namespace LeetcodeGrind.Solutions;

// 2317. Maximum XOR After Operations 
public class P2317
{
    public int MaximumXOR(int[] nums)
    {
        int max = 0;

        // The maximum possible XOR turns out
        // to be the OR of all the numbers ...
        foreach (int num in nums)
        {
            max |= num;
        }

        return max;
    }
}

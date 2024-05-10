namespace LeetcodeGrind.Solutions;

// 2997. Minimum Number of Operations to Make Array XOR Equal to K
public class P2997
{
    public int MinOperations(int[] nums, int k)
    {
        var xor = k;
        foreach (var num in nums)
        {
            xor ^= num;
        }

        return int.PopCount(xor);
    }
}

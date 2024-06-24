using System.Runtime.Intrinsics.Arm;

namespace LeetcodeGrind.Solutions;

// 3158. Find the XOR of Numbers Which Appear Twice
public class P3158
{
    public int DuplicateNumbersXOR(int[] nums)
    {
        var hs = new HashSet<int>(nums.Length);
        var xor = 0;

        foreach (var num in nums)
        {
            if (!hs.Add(num))
            {
                xor ^= num;
            }
        }

        return xor;
    }
}

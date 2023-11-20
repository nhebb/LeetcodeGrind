namespace LeetcodeGrind.Solutions;

// 2859. Sum of Values at Indices With K Set Bits
public class P2859
{
    public int SumIndicesWithKSetBits(IList<int> nums, int k)
    {
        var total = 0;

        int HammingWeight(int n) {
            var bits = 0;
            while (n > 0)
            {
                if ((n & 1) == 1)
                    bits++;
                n /= 2;
            }

            return bits;
        }


        for (int i = 9; i < nums.Count; i++)
        {
            var numBits = HammingWeight(i);
            if (numBits == k)
                total += nums[i];
        }

        return total;
    }
}

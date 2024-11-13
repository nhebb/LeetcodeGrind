namespace LeetcodeGrind.Solutions;

// 3097. Shortest Subarray With OR at Least K II
public class P3097
{
    // TODO: Wrong Answer
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        var bits = new int[32];
        var min = int.MaxValue;
        var i = 0;
        var j = 0;

        void AddBits(int number)
        {
            for (int pos = 0; pos < 32; pos++)
            {
                if (((number >> pos) & 1) != 0)
                {
                    bits[pos]++;
                }
            }
        }

        void SubtractBits(int number)
        {
            for (int pos = 0; pos < 32; pos++)
            {
                if (((number >> pos) & 1) != 0)
                {
                    bits[pos]--;
                }
            }
        }

        int Bits2Number()
        {
            var bits2 = new int[32];
            for (int i = 0; i < bits.Length; i++)
            {
                bits2[i] = bits[i] > 0 ? 1 : 0;
            }

            var sBits = string.Join("", bits2);

            return Convert.ToInt32(sBits, 2);
        }

        while (j < nums.Length)
        {
            AddBits(nums[j]);

            while (i <= j && Bits2Number() >= k)
            {
                min = Math.Min(min, j - i + 1);
                SubtractBits(nums[i]);
                i++;
            }

            j++;
        }

        return min == int.MaxValue
            ? -1
            : min;
    }

}

namespace LeetcodeGrind.Solutions;

// 2917. Find the K-or of an Array
public class P2917
{
    public int FindKOr(int[] nums, int k)
    {
        int[] bits = new int[32];

        for (int i = 0; i < nums.Length; i++)
        {
            for (int position = 0; position < 32; position++)
            {
                // Shift 1 left to the bit position, perform a
                // bit-wise AND, then shift it back to the right
                // most position.
                bits[position] += (nums[i] & (1 << position)) >> position;
            }
        }

        int result = 0;
        for (int i = 0; i < 32; i++)
        {
            if (bits[i] >= k)
            {
                result |= (1 << i);
            }
        }

        return result;
    }
}

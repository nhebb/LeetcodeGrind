namespace LeetcodeGrind.Solutions;

// 477. Total Hamming Distance
public class P0477
{
    public int TotalHammingDistance(int[] nums)
    {
        var sum = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                var val = (uint)(nums[i] ^ nums[j]);
                sum += (int)uint.PopCount(val);
            }
        }

        return sum;
    }
}

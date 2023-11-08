namespace LeetcodeGrind.Solutions;

// 2348. Number of Zero-Filled Subarrays - two solutions
public class P2348
{
    public long ZeroFilledSubarray(int[] nums)
    {
        var zeroArraylengths = new List<long>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                long len = 1;
                i++;
                while (i < nums.Length && nums[i] == 0)
                {
                    len++;
                    i++;
                }
                zeroArraylengths.Add(len);
                i--;
            }
        }
        long count = 0;
        foreach (var n in zeroArraylengths)
        {
            count += n * (n + 1) / 2;
        }
        return count;
    }

    public long ZeroFilledSubarray2(int[] nums)
    {
        long count = 0;
        long sequence = 0;
        foreach (var num in nums)
        {
            if (num == 0)
                sequence++;
            else
                sequence = 0;
            count += sequence;
        }
        return count;
    }
}

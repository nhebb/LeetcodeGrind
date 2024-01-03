namespace LeetcodeGrind.Solutions;

// 2980. Check if Bitwise OR Has Trailing Zeros
public class P2980
{
    public bool HasTrailingZeros(int[] nums)
    {
        var count = 0;
        foreach (var num in nums)
        {
            if (num % 2 == 0)
            {
                count++;
                if (count == 2)
                {
                    return true;
                }
            }
        }

        return false;
    }
}

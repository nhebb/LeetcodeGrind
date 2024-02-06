namespace LeetcodeGrind.Solutions;

// 1822. Sign of the Product of an Array
public class P1822
{
    public int ArraySign(int[] nums)
    {
        var neg = 0;
        foreach (var num in nums)
        {
            if (num == 0)
                return 0;
            else if (num < 0)
                neg++;
        }
        return neg % 2 == 0
            ? 1
            : -1;
    }

    public int ArraySignLINQ(int[] nums)
    {
        if (nums.Any(x => x == 0))
            return 0;

        return nums.Count(x => x < 0) % 2 == 1
            ? -1
            : 1;
    }
}

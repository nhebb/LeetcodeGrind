namespace LeetcodeGrind.Solutions;

// 2455. Average Value of Even Numbers That Are Divisible by Three
public class P2455
{
    public int AverageValue(int[] nums)
    {
        var sum = 0;
        var count = 0;
        foreach (var num in nums)
        {
            if (num % 6 == 0)
            {
                sum += num;
                count++;
            }
        }

        return count == 0 ? 0 : sum / count;
    }
}

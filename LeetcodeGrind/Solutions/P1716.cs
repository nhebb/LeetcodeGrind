namespace LeetcodeGrind.Solutions;

// 1716. Calculate Money in Leetcode Bank
public class P1716
{
    public int TotalMoney(int n)
    {
        var weeks = n / 7;
        var rem = n % 7;

        var sum = weeks > 0 ? Enumerable.Range(1, 7).Sum() : 0;
        var weekSum = sum;

        for (int i = 2; i <= weeks; i++)
        {
            weekSum += 7;
            sum += weekSum;
        }

        // calculate last week
        weekSum = 0;
        var start = weeks + 1;
        var end = start + rem - 1;
        for (int i = start; i <= end; i++)
        {
            weekSum += i;
        }
        sum += weekSum;

        return sum;
    }
}

namespace LeetcodeGrind.Solutions;

// 507. Perfect Number
public class P0507
{
    public bool CheckPerfectNumber(int num)
    {
        var divisors = new List<int>();
        divisors.Add(1);

        var n = num / 2;

        for (int i = 2; i <= n; i++)
        {
            if (num % i == 0)
            {
                divisors.Add(i);
            }
        }

        return divisors.Sum() == num;
    }
}

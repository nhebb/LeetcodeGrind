namespace LeetcodeGrind.Solutions;

// 2652. Sum Multiples
public class P2652
{
    public int SumOfMultiples(int n)
    {
        var sum = 0;

        for (int i = 3; i <= n; i++)
        {
            if (i % 3 == 0 || i % 5 == 0 || i % 7 == 0)
                sum += i;
        }

        return sum;
    }
}

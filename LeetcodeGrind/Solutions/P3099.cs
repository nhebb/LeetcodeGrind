namespace LeetcodeGrind.Solutions;

// 3099. Harshad Number
public class P3099
{
    public int SumOfTheDigitsOfHarshadNumber(int x)
    {
        var sum = 0;
        var num = x;
        while (x > 0)
        {
            sum += x % 10;
            x /= 10;
        }

        return num % sum == 0 ? sum : -1;
    }
}

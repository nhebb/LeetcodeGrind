namespace LeetcodeGrind.Solutions;

// 2520. Count the Digits That Divide a Number
public class P2520
{
    public int CountDigits(int num)
    {
        var val = num;
        var count = 0;

        while (val > 0)
        {
            var digit = val % 10;
            val = val / 10;

            if (digit == 0)
                continue;

            if (num % digit == 0)
                count++;
        }
        return count;
    }
}

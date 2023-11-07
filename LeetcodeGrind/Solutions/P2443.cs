namespace LeetcodeGrind.Solutions;

// 2443. Sum of Number and Its Reverse
public class P2443
{
    public bool SumOfNumberAndReverse(int num)
    {
        var half = num / 2;
        var num1 = num;

        int ReverseNum(int val)
        {
            var result = 0;
            while (val > 0)
            {
                result *= 10;
                result += val % 10;
                val /= 10;
            }

            return result;
        }

        while (num1 >= half)
        {
            var num2 = ReverseNum(num1);
            if (num1 + num2 == num)
                return true;

            num1--;
        }
        return false;
    }
}

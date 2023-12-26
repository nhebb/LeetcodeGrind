namespace LeetcodeGrind.Solutions;

// 2169. Count Operations to Obtain Zero

public class P2169
{
    public int CountOperations(int num1, int num2)
    {
        var numOps = 0;

        while (num1 > 0 && num2 > 0)
        {
            if (num1 > num2)
                num1 -= num2;
            else 
                num2 -= num1;

            numOps++;
        }

        return numOps;
    }
}

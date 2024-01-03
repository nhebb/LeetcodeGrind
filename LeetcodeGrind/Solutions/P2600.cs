namespace LeetcodeGrind.Solutions;

// 2600. K Items With the Maximum Sum
public class P2600
{
    public int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k)
    {
        var sum = 0;

        while (numOnes > 0 && k > 0)
        {
            sum++;
            k--;
            numOnes--;
        }
        if (k <= 0)
        {
            return sum;
        }

        while (numZeros > 0 && k > 0)
        {
            k--;
            numZeros--;
        }
        if (k <= 0)
        {
            return sum;
        }

        while (numNegOnes > 0 && k > 0)
        {
            sum--;
            k--;
            numNegOnes--;
        }
        return sum;
    }
}


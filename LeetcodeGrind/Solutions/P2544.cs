namespace LeetcodeGrind.Solutions;

// 2544. Alternating Digit Sum
public class P2544
{
    public int AlternateDigitSum(int n)
    {
        var sum = 0;
        var s = n.ToString();
        for (int i = 0; i < s.Length; i++)
        {
            var val = s[i] - '0';
            if (i % 2 == 0)
                sum += val;
            else
                sum -= val;
        }
        return sum;
    }
}

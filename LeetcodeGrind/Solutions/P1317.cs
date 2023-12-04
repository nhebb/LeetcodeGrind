namespace LeetcodeGrind.Solutions;

// 1317. Convert Integer to the Sum of Two No-Zero Integers
public class P1317
{
    public int[] GetNoZeroIntegers(int n)
    {
        for (int i = 1; i < n; i++)
        {
            if (!i.ToString().Contains('0') && !(n - i).ToString().Contains('0'))
                return new int[] { i, n - i };
        }

        return new int[] { -1, -1 };
    }
}

namespace LeetcodeGrind.Solutions;

// 2729. Check if The Number is Fascinating
public class P2729
{
    public bool IsFascinating(int n)
    {
        var num = n.ToString() + (n * 2).ToString() + (n * 3).ToString();
        var digits = num.ToCharArray();
        Array.Sort(digits);

        for (int i = 0; i < digits.Length; i++)
        {

            if (digits[i] - '0' != i + 1)
            {
                return false;
            }
        }

        return true;
    }
}

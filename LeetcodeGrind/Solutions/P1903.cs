namespace LeetcodeGrind.Solutions;

// 1903. Largest Odd Number in String
public class P1903
{
    public string LargestOddNumber(string num)
    {
        for (int i = num.Length - 1; i >= 0; i--)
        {
            if ((num[i] - '0') % 2 == 1)
            {
                return num.Substring(0, i + 1);
            }
        }

        return "";
    }
}

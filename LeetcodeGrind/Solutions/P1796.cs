using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1796. Second Largest Digit in a String
public class P1796
{
    public int SecondHighest(string s)
    {
        var hasDigit = new bool[10];

        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                hasDigit[s[i] - '0'] = true;
            }
        }

        var count = 0;
        for (int i = 9; i >= 0; i--)
        {
            if (hasDigit[i])
                count++;
            if (count == 2)
                return i;
        }

        return -1;
    }
}


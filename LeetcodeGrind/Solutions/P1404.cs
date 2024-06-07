namespace LeetcodeGrind.Solutions;

// 1404. Number of Steps to Reduce a Number in Binary Representation to One

public class P1404
{
    public int NumSteps(string s)
    {
        var steps = 0;
        var i = s.Length - 1;

        while (s[i] == '0')
        {
            steps++;
            i--;
        }

        var ones = 0;
        while (i >= 0)
        {
            if (s[i] == '0')
            {
                steps += ones + 1;
                ones = 1;
            }
            else
            {
                ones++;
            }

            i--;
        }

        if (ones > 1)
        {
            steps += ones + 1;
        }

        return steps;
    }
}

namespace LeetcodeGrind.Solutions;

// 678. Valid Parenthesis String
public class P0678
{
    public bool CheckValidString(string s)
    {
        var leftMin = 0;
        var leftMax = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                leftMin++;
                leftMax++;
            }
            else if (s[i] == ')')
            {
                leftMin--;
                leftMax--;
            }
            else
            {
                leftMin--;
                leftMax++;
            }

            if (leftMax < 0)
                return false;

            if (leftMin < 0)
                leftMin = 0;
        }

        return leftMin == 0;
    }
}


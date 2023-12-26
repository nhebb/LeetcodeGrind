namespace LeetcodeGrind.Solutions;

// 2124. Check if All A's Appears Before All B's
public class P2124
{
    public bool CheckString(string s)
    {
        var firstB = s.Length;
        var lastA = -1;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'b')
            {
                firstB = i;
                break;
            }
        }

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == 'a')
            {
                lastA = i;
                break;
            }
        }

        return lastA < firstB;
    }
}

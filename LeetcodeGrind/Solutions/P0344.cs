namespace LeetcodeGrind.Solutions;

// 344. Reverse String
public class P0344
{
    public void ReverseString(char[] s)
    {
        if (s == null || s.Length == 1) return;
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            (s[i], s[j]) = (s[j], s[i]);
            i++;
            j--;
        }
    }
}

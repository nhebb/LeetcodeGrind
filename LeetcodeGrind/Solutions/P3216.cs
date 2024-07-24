namespace LeetcodeGrind.Solutions;


// 3216. Lexicographically Smallest String After a Swap
public class P3216
{
    public string GetSmallestString(string s)
    {
        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i] % 2 == s[i + 1] % 2 && s[i] > s[i + 1])
            {
                var chars = s.ToCharArray();
                (chars[i], chars[i + 1]) = (chars[i + 1], chars[i]);
                return new string(chars);
            }
        }

        return s;
    }
}

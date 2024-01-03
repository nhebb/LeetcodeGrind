namespace LeetcodeGrind.Solutions;

// 1576. Replace All ?'s to Avoid Consecutive Repeating Characters
public class P1576
{
    public string ModifyString(string s)
    {
        if (s.Length == 1 && s[0] == '?')
            return "a";

        var chars = "abcdefghijklmnopqrstuvwyz".ToCharArray();
        var str = s.ToCharArray();

        var j = 0;
        for (int i = 1; i < str.Length - 1; i++)
        {
            if (s[i] == '?')
            {
                j = 0;
                while (chars[j] == str[i - 1] || chars[j] == str[i + 1])
                    j++;
                str[i] = chars[j];
            }
        }

        if (str[0] == '?')
        {
            j = 0;
            while (chars[j] == str[1])
                j++;
            str[0] = chars[j];
        }

        if (str[^1] == '?')
        {
            j = 0;
            while (chars[j] == str[^2])
                j++;
            str[^1] = chars[j];
        }

        return new string(str);
    }
}

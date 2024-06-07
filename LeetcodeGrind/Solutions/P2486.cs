namespace LeetcodeGrind.Solutions;

// 2486. Append Characters to String to Make Subsequence
public class P2486
{
    public int AppendCharacters(string s, string t)
    {
        var j = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == t[j])
            {
                j++;
                if (j == t.Length)
                {
                    break;
                }
            }
        }

        return t.Length - j;
    }
}

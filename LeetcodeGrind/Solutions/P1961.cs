namespace LeetcodeGrind.Solutions;

// 1961. Check If String Is a Prefix of Array
public class P1961
{
    public bool IsPrefixString(string s, string[] words)
    {
        var test = "";
        for (int i = 0; i < words.Length; i++)
        {
            test += words[i];
            if (test.Length >= s.Length)
            {
                break;
            }
        }

        return test == s;
    }
}

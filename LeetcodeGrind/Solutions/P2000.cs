namespace LeetcodeGrind.Solutions;

// 2000. Reverse Prefix of Word
public class P2000
{
    public string ReversePrefix(string word, char ch)
    {
        var j = word.IndexOf(ch);
        if (j < 0)
            return word;

        var chars = word.ToCharArray();
        int i = 0;
        while (i < j)
        {
            (chars[i], chars[j]) = (chars[j], chars[i]);
            i++;
            j--;
        }

        return new string(chars);
    }
}

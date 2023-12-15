namespace LeetcodeGrind.Solutions;

// 2788. Split Strings by Separator
public class P2788
{
    public IList<string> SplitWordsBySeparator(IList<string> words, char separator)
    {
        var res = new List<string>();

        for (int i = 0; i < words.Count; i++)
        {
            res.AddRange(words[i].Split(separator, StringSplitOptions.RemoveEmptyEntries));
        }

        return res;
    }
}

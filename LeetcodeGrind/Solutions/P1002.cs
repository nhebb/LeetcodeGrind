namespace LeetcodeGrind.Solutions;

// 1002. Find Common Characters
public class P1002
{
    public IList<string> CommonChars(string[] words)
    {
        // Wrong answer. Must include  duplicated characters
        IEnumerable<char> hs = words[0].ToList();
        for (int i = 1; i < words.Length; i++)
        {
            hs = hs.Intersect(words[i]);
        }

        var result = new List<string>();
        foreach (char c in hs)
        {
            result.Add(c.ToString());
        }

        return result;
    }

}

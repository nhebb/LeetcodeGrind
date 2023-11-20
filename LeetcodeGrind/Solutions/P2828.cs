namespace LeetcodeGrind.Solutions;

// 2828. Check if a String Is an Acronym of Words
public class P2828
{
    public bool IsAcronym(IList<string> words, string s)
    {
        var firsts = words.Select(x => x[0]);
        var acronym = string.Join("", firsts);
        return acronym == s;
    }
}

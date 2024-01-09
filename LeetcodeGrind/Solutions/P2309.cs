namespace LeetcodeGrind.Solutions;

// 2309. Greatest English Letter in Upper and Lower Case
public class P2309
{
    public string GreatestLetter(string s)
    {
        var hsUpper = new HashSet<char>(s.Length);
        var hsLower = new HashSet<char>(s.Length);
        foreach (var c in s)
        {
            if (char.IsUpper(c))
                hsUpper.Add(c);
            else
                hsLower.Add(c);
        }

        var both = new List<char>();
        foreach (var c in hsUpper)
        {
            if (hsLower.Contains(char.ToLower(c)))
            {
                both.Add(c);
            }
        }

        if (both.Count == 0)
            return "";
        else
            return both.Max().ToString();
    }
}

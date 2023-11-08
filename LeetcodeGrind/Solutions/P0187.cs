namespace LeetcodeGrind.Solutions;

// 187. Repeated DNA Sequences
public class P0187
{
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        if (s.Length <= 10)
            return new List<string>();

        var res = new HashSet<string>();
        var hs = new HashSet<string>();
        Span<char> dna = s.ToCharArray();
        var i = 0;
        var j = 10;
        while (j <= s.Length)
        {
            var seq = dna.Slice(i, j - i).ToString();
            // 2 hashsets - first detects duplicates,
            // and second ensures unique results
            if (!hs.Add(seq))
                res.Add(seq);
            i++;
            j++;
        }

        return res.ToList();
    }
}

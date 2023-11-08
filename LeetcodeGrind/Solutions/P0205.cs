namespace LeetcodeGrind.Solutions;

// 205. Isomorphic Strings
public class P0205
{
    public bool IsIsomorphic(string s, string t)
    {
        if (s.Length != t.Length) { return false; }
        if (s == t || s.Length == 1) { return true; }

        var sdict = new Dictionary<char, int>();
        var tdict = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!sdict.ContainsKey(s[i]))
                sdict[s[i]] = i;
            if (!tdict.ContainsKey(t[i]))
                tdict[t[i]] = i;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (sdict[s[i]] != tdict[t[i]])
                return false;
        }
        return true;
    }
}

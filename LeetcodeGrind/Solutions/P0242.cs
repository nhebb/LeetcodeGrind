using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 242. Valid Anagram
public class P0242
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) { return false; }

        var dict = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (dict.TryGetValue(s[i], out var val))
                dict[s[i]] = val + 1;
            else
                dict[s[i]] = 1;
        }
        for (int i = 0; i < t.Length; i++)
        {
            if (!dict.ContainsKey(t[i]))
                return false;

            dict[t[i]] -= 1;
            if (dict[t[i]] == 0)
                dict.Remove(t[i]);
        }
        return true;
    }

}


namespace LeetcodeGrind.Solutions;

// 567. Permutation in String
public class P0567
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        if (s2.Contains(s1))
            return true;

        var counts1 = new Dictionary<char, int>();
        var counts2 = new Dictionary<char, int>();

        foreach (var c in s1)
        {
            if (!counts1.TryAdd(c, 1))
                counts1[c]++;
        }

        foreach (var c in s2.Substring(0, s1.Length))
        {
            if (!counts2.TryAdd(c, 1))
                counts2[c]++;
        }

        bool isMatch = true;
        foreach (var kvp in counts1)
        {
            if (!counts2.ContainsKey(kvp.Key) ||
                counts2[kvp.Key] != kvp.Value)
            {
                isMatch = false;
                break;
            }
        }
        if (isMatch) return true;

        for (int i = 1, j = s1.Length; j < s2.Length; i++, j++)
        {
            counts2[s2[i - 1]]--;
            if (!counts2.TryAdd(s2[j], 1))
                counts2[s2[j]]++;

            isMatch = true;
            foreach (var kvp in counts1)
            {
                if (!counts2.ContainsKey(kvp.Key) ||
                    counts2[kvp.Key] != kvp.Value)
                {
                    isMatch = false;
                    break;
                }
            }
            if (isMatch) return true;
        }
        return false;
    }
}

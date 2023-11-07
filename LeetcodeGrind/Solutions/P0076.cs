namespace LeetcodeGrind.Solutions;

// 76. Minimum Window Substring
public class P0076
{
    public string MinWindow(string s, string t)
    {
        if (string.IsNullOrEmpty(t)) return "";

        var window = new Dictionary<char, int>();
        var countT = new Dictionary<char, int>();

        foreach (char c in t)
        {
            if (!countT.ContainsKey(c))
                countT[c] = 0;
            countT[c]++;
        }

        var need = countT.Keys.Count;
        var have = 0;
        var resLen = s.Length + 1;
        var res = new int[] { -1, -1 };
        //var i = 0;
        var i = 0;

        for (int j = 0; j < s.Length; j++)
        {
            char c = s[j];
            if (!window.ContainsKey(c))
                window[c] = 0;
            window[c]++;

            if (countT.ContainsKey(c) && window[c] == countT[c])
                have++;

            while (have == need)
            {
                if (j - i + 1 < resLen)
                {
                    res[0] = i;
                    res[1] = j;
                    resLen = j - i + 1;
                }

                window[s[i]]--;
                if (countT.ContainsKey(s[i]) && window[s[i]] < countT[s[i]])
                    have--;
                i++;
            }
        }
        if (resLen <= s.Length)
            return s.Substring(res[0], res[1] - res[0] + 1);
        return "";
    }

}


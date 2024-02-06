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
        var resultLength = s.Length + 1;
        var result = new int[] { -1, -1 };
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
                var curLength = j - i + 1;
                if (curLength < resultLength)
                {
                    result[0] = i;
                    result[1] = j;
                    resultLength = curLength;
                }

                window[s[i]]--;
                if (countT.ContainsKey(s[i]) && window[s[i]] < countT[s[i]])
                    have--;
                i++;
            }
        }

        if (resultLength <= s.Length)
            return s.Substring(result[0], result[1] - result[0] + 1);
        return "";
    }

}

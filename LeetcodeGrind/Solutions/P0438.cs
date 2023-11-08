namespace LeetcodeGrind.Solutions;

// 438. Find All Anagrams in a String
public class P0438
{
    public IList<int> FindAnagrams(string s, string p)
    {
        var ans = new List<int>();
        var sd = new Dictionary<char, int>();
        var pd = new Dictionary<char, int>();
        foreach (var c in p)
        {
            sd[c] = 0;
            if (pd.ContainsKey(c))
                pd[c]++;
            else
                pd[c] = 1;
        }

        var need = p.Length;
        for (int i = 0; i < p.Length; i++)
        {
            if (sd.ContainsKey(s[i]))
            {
                sd[s[i]]++;
                if (sd[s[i]] <= pd[s[i]])
                    need--;
            }
        }

        if (need == 0)
            ans.Add(0);

        for (int i = 1, j = p.Length; j < s.Length; i++, j++)
        {

            if (sd.ContainsKey(s[i - 1]))
            {
                var lastChar = s[i - 1];
                sd[lastChar]--;
                if (sd[lastChar] < pd[lastChar])
                    need++;
            }

            if (sd.ContainsKey(s[j]))
            {
                var nextChar = s[j];
                sd[nextChar]++;
                if (sd[nextChar] <= pd[nextChar])
                    need--;
            }

            if (need == 0)
                ans.Add(i);
        }

        return ans;
    }
}

namespace LeetcodeGrind.Solutions;

// 1461. Check If a String Contains All Binary Codes of Size K
public class P1461
{
    public bool HasAllCodes(string s, int k)
    {
        var hs = new HashSet<int>();
        for (int i = 0; i <= s.Length - k; i++)
        {
            hs.Add(Convert.ToInt32(s.Substring(i, k), 2));
        }

        var limit = (int)Math.Pow(2, k);
        for (int i = 0; i < limit; i++)
        {
            if (!hs.Contains(i))
                return false;
        }
        return true;
    }
}

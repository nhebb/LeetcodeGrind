namespace LeetcodeGrind.Solutions;

// 3. Longest Substring Without Repeating Characters
public class P0003
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s)) { return 0; }

        var hs = new HashSet<char>();
        int max = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int len = 0;
            for (int j = i; j < s.Length; j++)
            {
                if (!hs.Add(s[j]))
                {
                    break;
                }
                len++;
            }
            max = Math.Max(max, len);
            hs.Clear();
        }
        return max;
    }
}

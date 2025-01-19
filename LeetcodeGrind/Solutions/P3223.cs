namespace LeetcodeGrind.Solutions;

// 3223. Minimum Length of String After Operations
public class P3223
{
    public int MinimumLength(string s)
    {
        var counts = new int[26];
        for (var i = 0; i < s.Length;i++)
        {
            counts[s[i] - 'a']++;
        }

        var deleted = 0;
        for (var i = 0; i < counts.Length; i++)
        {
            var count = counts[i];
            if (count > 2)
            {
                if (count % 2 == 0)
                    deleted += count - 2;
                else
                    deleted += count - 1;
            }
        }

        return s.Length - deleted;
    }
}

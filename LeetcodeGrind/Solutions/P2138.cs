namespace LeetcodeGrind.Solutions;

// 2138. Divide a String Into Groups of Size k
public class P2138
{
    public string[] DivideString(string s, int k, char fill)
    {
        var rem = s.Length % k;
        if (rem != 0)
        {
            s += new string(fill, k - rem);
        }

        var result = new List<string>();
        var skip = 0;

        while (skip < s.Length)
        {
            result.Add(string.Join("", s.Skip(skip).Take(k)));
            skip += k;
        }

        return result.ToArray();
    }
}

namespace LeetcodeGrind.Solutions;

// 880. Decoded String at Index
public class P0880
{
    public string DecodeAtIndex(string s, int k)
    {
        // Note: Trying to build the string will result
        // in an "out of memory" error.

        var result = "";
        long len = 0;

        // Traverse left to right to get a length of the string (characters only)
        foreach (var c in s)
        {
            if (char.IsLetter(c))
                len++;
            else
                len *= c - '0'; // recalc len
        }

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(s[i]))
            {
                len /= s[i] - '0';  // reduce len
                k = (int)(k % len); // magic modulo arithmetic
            }
            else
            {
                if (k == 0 || k == len)
                {
                    result = s[i].ToString();
                    break;
                }
                len--;
            }
        }

        return result;
    }
}

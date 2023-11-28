namespace LeetcodeGrind.Solutions;

// 806. Number of Lines To Write String
public class P0806
{
    public int[] NumberOfLines(int[] widths, string s)
    {
        var lines = 0;
        var len = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var charLen = widths[s[i] - 'a'];
            if (charLen + len == 100)
            {
                lines++;
                len = 0;
            }
            else if (charLen + len > 100)
            {
                lines++;
                len = charLen;
            }
            else
            {
                len += charLen;
            }
        }

        if (len > 0)
        {
            lines++;
        }

        var lastLen = len == 0 ? 100 : len;

        return new int[] { lines, lastLen };
    }
}

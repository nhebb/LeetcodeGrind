using System.Text;

namespace LeetcodeGrind.Solutions;

// 6. Zigzag Conversion
public class P0006
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1 || string.IsNullOrWhiteSpace(s))
            return s;

        var sb = new StringBuilder();
        var len = s.Length;
        var offset = 2 * numRows - 2;

        for (int i = 0; i < numRows; i++)
        {
            if (i == 0 || i == numRows - 1)
            {
                // top and bottom characters (offset = 2n-2)
                for (int j = i; j < len; j += offset)
                    sb.Append(s[j]);
            }
            else
            {
                // diagonal characters (dynamic offset)
                int j = i;
                bool down = true;
                int downOffset = 2 * (numRows - 1 - i);
                int upOffset = offset - downOffset;
                while (j < len)
                {
                    sb.Append(s[j]);
                    if (down)
                        j += downOffset;
                    else
                        j += upOffset;
                    down = !down;
                }
            }
        }
        return sb.ToString();
    }
}

using System.Text;

namespace LeetcodeGrind.Solutions;

// 2109. Adding Spaces to a String
public class P2109
{
    public string AddSpaces(string s, int[] spaces)
    {
        var sb = new StringBuilder(s.Length + spaces.Length);
        var j = 0;

        for (int i = 0; i < s.Length; i++)
        {
            while (j < spaces.Length && i == spaces[j])
            {
                sb.Append(' ');
                j++;
            }
            sb.Append(s[i]);
        }

        return sb.ToString();
    }
}

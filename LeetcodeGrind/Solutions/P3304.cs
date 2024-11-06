using System.Text;

namespace LeetcodeGrind.Solutions;

// 304. Find the K-th Character in String Game I
public class P3304
{
    public char KthCharacter(int k)
    {
        var sb = new StringBuilder(1024);
        sb.Append('a');

        while (sb.Length < k)
        {
            var s = sb.ToString();
            foreach (var c in s)
            {
                sb.Append((char)(c + 1));
            }
        }

        return sb.ToString()[k - 1];
    }
}

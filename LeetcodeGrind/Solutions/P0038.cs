using System.Text;

namespace LeetcodeGrind.Solutions;

// 38. Count and Say
public class P0038
{
    public string CountAndSay(int n)
    {
        var s = "1";
        var sb = new StringBuilder();

        for (int i = 2; i <= n; i++)
        {
            var j = 0;
            while (j < s.Length)
            {
                var val = s[j] - '0';
                var count = 1;
                while (j < s.Length - 1 && s[j + 1] == s[j])
                {
                    count++;
                    j++;
                }
                sb.Append(count).Append(val);
                j++;
            }
            s = sb.ToString();
            sb.Clear();
        }
        return s;
    }
}

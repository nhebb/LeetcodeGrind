namespace LeetcodeGrind.Solutions;

// 2609. Find the Longest Balanced Substring of a Binary String
public class P2609
{
    public int FindTheLongestBalancedSubstring(string s)
    {
        s = s.Replace("01", "0,1").Replace("10", "1,0");
        var spans = s.Split(',', StringSplitOptions.RemoveEmptyEntries);

        var max = 0;

        for (int i = 0; i < spans.Length - 1; i++)
        {
            if (spans[i][0] == '0')
            {
                var curSpan = Math.Min(spans[i].Length, spans[i + 1].Length);
                max = Math.Max(max, 2 * curSpan);
            }
        }

        return max;
    }
}

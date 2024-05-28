namespace LeetcodeGrind.Solutions;

// 1208. Get Equal Substrings Within Budget
public class P1208
{
    public int EqualSubstring(string s, string t, int maxCost)
    {
        var cost = 0;
        var maxLen = 0;
        var i = 0;

        for (int j = 0; j < s.Length; j++)
        {
            cost += Math.Abs(s[j] - t[j]);
            if (cost <= maxCost)
            {
                maxLen = Math.Max(j - i + 1, maxLen);
            }
            else
            {
                while (i <= j && cost > maxCost)
                {
                    cost -= Math.Abs(s[i] - t[i]);
                    i++;
                }
            }
        }

        return maxLen;
    }
}

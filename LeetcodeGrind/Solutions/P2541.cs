namespace LeetcodeGrind.Solutions;

// 2451. Odd String Difference
public class P2541
{
    public string OddString(string[] words)
    {
        var diffs = new int[words[0].Length - 1];
        var diffCounts = new Dictionary<string, List<int>>();

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 1; j < words[i].Length; j++)
            {
                diffs[j - 1] = words[i][j] - words[i][j - 1];
            }

            var s = string.Join(',', diffs);
            if (diffCounts.ContainsKey(s))
            {
                diffCounts[s].Add(i);
            }
            else
            {
                diffCounts[s]=new List<int> { i };
            }
        }

        foreach (var kvp in diffCounts)
        {
            if (kvp.Value.Count == 1)
            {
                return words[kvp.Value[0]];
            }
        }

        return "";
    }
}

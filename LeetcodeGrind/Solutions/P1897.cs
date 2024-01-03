namespace LeetcodeGrind.Solutions;

// 1897. Redistribute Characters to Make All Strings Equal
public class P1897
{
    public bool MakeEqual(string[] words)
    {
        var n = words.Length;
        var charCounts = new Dictionary<char, int>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                if (charCounts.ContainsKey(words[i][j]))
                {
                    charCounts[words[i][j]]++;
                }
                else
                {
                    charCounts[words[i][j]] = 1;
                }
            }
        }

        foreach (var kvp in charCounts)
        {
            if (kvp.Value % n != 0)
            {
                return false;
            }
        }

        return true;
    }
}

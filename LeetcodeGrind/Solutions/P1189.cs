namespace LeetcodeGrind.Solutions;

// 1189. Maximum Number of Balloons
public class P1189
{
    public int MaxNumberOfBalloons(string text)
    {
        var charCounts = new Dictionary<char, int>();
        var validChars = "balon";

        foreach (var c in text)
        {
            if (validChars.Contains(c))
            {
                if (!charCounts.TryAdd(c, 1))
                {
                    charCounts[c]++;
                }
            }
        }

        foreach (var c in validChars)
        {
            if (!charCounts.ContainsKey(c))
                return 0;
        }

        var numLO = Math.Min(charCounts['l'], charCounts['o']) / 2; // l and o appear twice
        var numABN = Math.Min(Math.Min(charCounts['a'], charCounts['b']), charCounts['n']);

        return Math.Min(numLO, numABN);
    }
}

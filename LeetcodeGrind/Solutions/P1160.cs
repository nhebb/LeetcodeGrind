namespace LeetcodeGrind.Solutions;

// 1160. Find Words That Can Be Formed by Characters
public class P1160
{
    public int CountCharacters(string[] words, string chars)
    {
        var charsDict = chars.GroupBy(x => x)
                             .ToDictionary(g => g.Key, g => g.Count());
        var count = 0;

        foreach (var word in words)
        {
            var wordDict = word.GroupBy(x => x)
                               .ToDictionary(g => g.Key, g => g.Count());

            var match = true;
            foreach (var kvp in wordDict)
            {
                if (!charsDict.ContainsKey(kvp.Key) || charsDict[kvp.Key] < kvp.Value)
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                count += word.Length;
            }
        }

        return count;
    }
}

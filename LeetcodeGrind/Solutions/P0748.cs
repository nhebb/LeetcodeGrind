namespace LeetcodeGrind.Solutions;

// 748. Shortest Completing Word
public class P0748
{
    public string ShortestCompletingWord(string licensePlate, string[] words)
    {
        licensePlate = licensePlate.ToLower();
        var baseLetters = new Dictionary<char, int>();
        foreach (var c in licensePlate)
        {
            if (char.IsLetter(c))
            {
                if (!baseLetters.TryAdd(c, 1))
                    baseLetters[c]++;
            }
        }

        var shortestLen = int.MaxValue;
        var shortest = "";
        foreach (var word in words)
        {
            var lower = word.ToLower();
            var wordLetters = lower.GroupBy(c => c)
                                  .ToDictionary(g => g.Key, g => g.Count());

            var match = true;
            foreach (var kvp in baseLetters)
            {
                if (!wordLetters.ContainsKey(kvp.Key) ||
                    wordLetters[kvp.Key] < kvp.Value)
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                if (word.Length < shortestLen)
                {
                    shortest = word;
                    shortestLen = word.Length;
                }
            }
        }

        return shortest;
    }
}

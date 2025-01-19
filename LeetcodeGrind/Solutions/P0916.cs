namespace LeetcodeGrind.Solutions;

// 916. Word Subsets
public class P0916
{
    public IList<string> WordSubsets(string[] words1, string[] words2)
    {
        var result = new List<string>();

        var targetCounts = new int[26];
        var currentCounts = new int[26]; ;

        foreach (var word in words2)
        {
            GetCharCounts(word, currentCounts);
            for (int i = 0; i < 26; i++)
            {
                targetCounts[i] = Math.Max(targetCounts[i], currentCounts[i]);
            }
        }

        var minLength = targetCounts.Sum();

        foreach (var word in words1)
        {
            if (word.Length < minLength)
                continue;

            GetCharCounts(word, currentCounts);
            if (IsSubset(currentCounts, targetCounts))
            {
                result.Add(word);
            }
        }
        return result;
    }

    private void GetCharCounts(string word, int[] counts)
    {
        Array.Fill(counts, 0);
        foreach (var c in word)
        {
            counts[c - 'a']++;
        }
    }

    private bool IsSubset(int[] wordChars, int[] requiredCounts)
    {
        for (int i = 0; i < 26; i++)
        {
            if (wordChars[i] < requiredCounts[i])
            {
                return false;
            }
        }
        return true;
    }
}

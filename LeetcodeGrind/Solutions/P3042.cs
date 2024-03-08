namespace LeetcodeGrind.Solutions;

// 3042. Count Prefix and Suffix Pairs I
public class P3042
{
    public int CountPrefixSuffixPairs(string[] words)
    {
        var sorted = words.OrderBy(w => w.Length)
                          .ToArray();

        var pairs = 0;

        for (int i = 0; i < words.Length - 1; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                if (words[j].StartsWith(words[i]) &&
                    words[j].EndsWith(words[i]))
                {
                    pairs++;
                }
            }
        }

        return pairs;
    }
}

namespace LeetcodeGrind.Solutions;

// 2559. Count Vowel Strings in Ranges

public class P2559
{
    public int[] VowelStrings(string[] words, int[][] queries)
    {
        var vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };

        var prefix = new int[words.Length];
        if (vowels.Contains(words[0][0]) && vowels.Contains(words[0][^1]))
            prefix[0] = 1;

        for (int i = 1; i < words.Length; i++)
        {
            prefix[i] = prefix[i - 1];
            if (vowels.Contains(words[i][0]) && vowels.Contains(words[i][^1]))
                prefix[i]++;
        }

        var result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            var startValue = queries[i][0] == 0
                ? 0
                : prefix[queries[i][0] - 1];
            var endVal = prefix[queries[i][1]];
            result[i] = endVal - startValue;
        }

        return result;
    }
}

namespace LeetcodeGrind.Solutions;

// 2586. Count the Number of Vowel Strings in Range
public class P2586
{
    public int VowelStrings(string[] words, int left, int right)
    {
        var vowels = "aeiou".ToHashSet<char>();
        var count = 0;

        for (int i = left; i <= right; i++)
        {
            if (vowels.Contains(words[i][0]) && vowels.Contains(words[i][^1]))
                count++;
        }

        return count;
    }
}

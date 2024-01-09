namespace LeetcodeGrind.Solutions;

// 2062. Count Vowel Substrings of a String
public class P2062
{
    public int CountVowelSubstrings(string word)
    {
        // Use non-vowels as string split separators and filter by
        // vowel spans w/ length >= 5.
        var separators = "bcdfghjklmnpqrstvwxyz".ToCharArray();
        var strs = word.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                       .Where(x => x.Length >= 5)
                       .ToList();

        // Brute force over all possible substrings w/ length >= 5.
        // i is the starting index, and j is the substring length.
        var count = 0;
        foreach (var str in strs)
        {
            for (int i = 0; i <= str.Length - 5; i++)
            {
                for (int j = 5; i + j <= str.Length; j++)
                {
                    var s = str.Substring(i, j);
                    if (s.Contains('a') && s.Contains('e') &&
                        s.Contains('i') && s.Contains('o') &&
                        s.Contains('u'))
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
}

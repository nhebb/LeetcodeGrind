namespace LeetcodeGrind.Solutions;

//290. Word Pattern
public class P0290
{
    public bool WordPattern(string pattern, string s)
    {
        var words = s.Split(' ');

        if (pattern.Length != words.Length)
            return false;

        // The Dictionary 'd' is used to ensure that each letter
        // in the pattern maps to only one word.
        var d = new Dictionary<char, string>();

        // The hashSet 'hs' is used to check the converse - that
        // each word maps to only one letter in the pattern.
        var hs = new HashSet<string>();

        for (int i = 0; i < pattern.Length; i++)
        {
            if (d.TryGetValue(pattern[i], out var val))
            {
                // Check if this pattern letter is mapped
                // to a different word.
                if (val != words[i])
                    return false;
            }
            else
            {
                // If we can't add the word to the HashSet,
                // then the word was already used for another
                // letter in the pattern.
                if (!hs.Add(words[i]))
                    return false;

                // Map the letter to the word
                d[pattern[i]] = words[i];
            }
        }
        return true;
    }
}

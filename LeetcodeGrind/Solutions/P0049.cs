namespace LeetcodeGrind.Solutions;

// 49. Group Anagrams
public class P0049
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var anagrams = new Dictionary<string, List<string>>();
        foreach (var str in strs)
        {
            // Sort then join the str characters to form the
            // dictionary key, and add str to the anagram dictionary
            var anagram = string.Join("", str.Order());
            if (!anagrams.ContainsKey(anagram))
                anagrams[anagram] = [];
            anagrams[anagram].Add(str);
        }

        var result = new List<IList<string>>();

        // Each Value in the Key-Value Pair (kvp) is a
        // list of anagrams grouped by common letters.
        foreach (var kvp in anagrams)
        {
            result.Add(kvp.Value);
        }

        return result;
    }
}

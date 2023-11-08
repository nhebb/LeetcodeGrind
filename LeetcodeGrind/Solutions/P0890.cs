namespace LeetcodeGrind.Solutions;

// 
public class P0890
{
    // 890. Find and Replace Pattern
    public IList<string> FindAndReplacePattern(string[] words, string pattern)
    {
        // create index pattern
        var patternDict = new Dictionary<char, int>();
        var indexList = new List<int>();

        // Create a pattern based on the first index that each
        // letter appears in the string. "mee" would be "0,1,1"
        string CreatePattern(string s)
        {
            // clear between calls
            indexList.Clear();
            patternDict.Clear();

            for (int i = 0; i < s.Length; i++)
            {
                if (!patternDict.ContainsKey(s[i]))
                    patternDict[s[i]] = i;
            }
            foreach (var c in s)
                indexList.Add(patternDict[c]);
            return string.Join(",", indexList);
        }

        var ans = new List<string>();
        var basePattern = CreatePattern(pattern);

        foreach (var word in words)
        {
            if (CreatePattern(word) == basePattern)
                ans.Add(word);
        }

        return ans;
    }
}

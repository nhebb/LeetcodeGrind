using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1657. Determine if Two Strings Are Close
public class P1657
{
    public bool CloseStrings(string word1, string word2)
    {
        if (word1.Length != word2.Length ||
            word1.Except(word2).Count() > 0 ||
            word2.Except(word1).Count() > 0)
        {
            return false;
        }

        var l1 = word1.GroupBy(c => c)
                      .ToDictionary(g => g.Key, g => g.Count())
                      .Select(g => g.Value)
                      .OrderBy(x => x)
                      .ToList();
        var l2 = word2.GroupBy(c => c)
                      .ToDictionary(g => g.Key, g => g.Count())
                      .Select(g => g.Value)
                      .OrderBy(x => x)
                      .ToList();

        return l1.SequenceEqual(l2);
    }
}


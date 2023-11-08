namespace LeetcodeGrind.Solutions;

// 2506. Count Pairs Of Similar Strings
public class P2506
{
    public int SimilarPairs(string[] words)
    {
        var strs = new string[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            var hs = new HashSet<char>(words[i]);
            strs[i] = string.Join("", hs.OrderBy(x => x));
            //strs[i] = new string(words[i].OrderBy(x => x).Distinct().ToArray());
        }

        var count = 0;
        for (int i = 0; i < strs.Length - 1; i++)
        {
            for (int j = i + 1; j < strs.Length; j++)
            {
                if (strs[i] == strs[j])
                    count++;
            }
        }
        return count;
    }
}

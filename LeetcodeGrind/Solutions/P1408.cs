namespace LeetcodeGrind.Solutions;

// 1408. String Matching in an Array
public class P1408
{
    public IList<string> StringMatching(string[] words)
    {
        var ans = new List<string>();
        var hs = new HashSet<string>();

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words.Length; j++)
            {
                if (i == j)
                    continue;

                if (words[i].Contains(words[j]) && !hs.Contains(words[j]))
                {
                    ans.Add(words[j]);
                    hs.Add(words[j]);
                }

                if (words[j].Contains(words[i]) && !hs.Contains(words[i]))
                {
                    ans.Add(words[i]);
                    hs.Add(words[i]);
                }
            }
        }

        return ans;
    }
}

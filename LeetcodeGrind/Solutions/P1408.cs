namespace LeetcodeGrind.Solutions;

// 1408. String Matching in an Array
public class P1408
{
    public IList<string> StringMatching(string[] words)
    {
        var hs = new HashSet<string>();

        for (int i = 0; i < words.Length - 1; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                if (i == j)
                    continue;

                if (words[i].Contains(words[j]))
                {
                    hs.Add(words[j]);
                }

                if (words[j].Contains(words[i]))
                {
                    hs.Add(words[i]);
                }
            }
        }

        return hs.ToList();
    }
}

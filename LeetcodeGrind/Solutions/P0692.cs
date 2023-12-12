namespace LeetcodeGrind.Solutions;

// 692. Top K Frequent Words
public class P0692
{
    public IList<string> TopKFrequent(string[] words, int k)
    {
        return words.GroupBy(x => x)
                    .OrderByDescending(g => g.Count())
                    .ThenBy(g => g.Key)
                    .Take(k)
                    .Select(g => g.Key)
                    .ToList();
    }
}

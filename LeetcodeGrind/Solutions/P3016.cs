namespace LeetcodeGrind.Solutions;

// 3016. Minimum Number of Pushes to Type Word II
public class P3016
{
    private class LetterCount
    {
        public char Letter { get; set; }
        public int Count { get; set; }
    }

    public int MinimumPushes(string word)
    {
        var d = word.GroupBy(c => c)
                    .ToDictionary(g => g.Key, g => g.Count());

        var letterCounts = new List<LetterCount>();
        foreach (var kv in d)
        {
            letterCounts.Add(new LetterCount
            {
                Letter = kv.Key,
                Count = kv.Value
            });
        }

        var descLetterCounts = letterCounts.OrderByDescending(c => c.Count)
                                           .ToList();

        var pushes = 0;

        for (int i = 0; i < descLetterCounts.Count; i++)
        {
            // number of times to push key
            var times = i / 8 + 1;
            pushes += descLetterCounts[i].Count * times;
        }

        return pushes;
    }
}

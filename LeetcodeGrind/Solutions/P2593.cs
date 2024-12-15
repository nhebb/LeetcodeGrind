namespace LeetcodeGrind.Solutions;

// 2593. Find Score of an Array After Marking All Elements
public class P2593
{
    private class NumberItem
    {
        public int Value { get; set; }
        public int Index { get; set; }
    }

    public long FindScore(int[] nums)
    {
        var items = new List<NumberItem>(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            items.Add(new NumberItem
            {
                Value = nums[i],
                Index = i
            });
        }

        var sorted = items.OrderBy(x => x.Value)
                          .ThenBy(x => x.Index)
                          .ToList();

        var marked = new HashSet<int>(nums.Length);
        long score = 0;

        foreach (var item in sorted)
        {
            var index = item.Index;
            if (marked.Contains(index))
                continue;

            score += item.Value;

            marked.Add(index - 1);
            marked.Add(index);
            marked.Add(index + 1);
        }

        return score;
    }
}
